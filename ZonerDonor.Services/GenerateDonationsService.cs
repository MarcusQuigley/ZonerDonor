using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;
using Timers = System.Timers;
using ZonerDonor.Utils.Extensions;

namespace ZonerDonor.Services
{
    public class GenerateDonationsService : IHostedService, IDisposable
    {
        readonly Timers.Timer timer;
 
        readonly IServiceScopeFactory scopeFactory;
        private int numberPerMinute = 10;
        ILogger<GenerateDonationsService> logger;
        IEnumerable<Guid> donorIds;
        IEnumerable<Guid> fundraiserIds;

        public GenerateDonationsService(
            IServiceScopeFactory scopeFactory,
            ILogger<GenerateDonationsService> logger)
        {
            this.scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            timer = new Timers.Timer(CalculateInterval(NumberPerMinute));
            timer.Elapsed  += Timer_Elapsed;
         }

        public int NumberPerMinute
        {
            set
            {
                numberPerMinute = value;
                timer.Interval = CalculateInterval(numberPerMinute);
                logger.LogWarning($"Auto Donations changed to every {timer.Interval} ms");
            }
            get => numberPerMinute;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Start();
            return Task.CompletedTask;
        }

        private async void Timer_Elapsed(object sender, Timers.ElapsedEventArgs e)
        {
          await  CreateDonation();
        }
        private async Task CreateDonation()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var fundraiserRepository = scope.ServiceProvider.GetService<IFundraiserRepository>();
                var donationRepository = scope.ServiceProvider.GetService<IDonationRepository>();

                if (donorIds == null)
                {
                    var donorRepository = scope.ServiceProvider.GetService<IDonorRepository>();
                    donorIds = await donorRepository.GetDonorIdsAsync();
                }

                if (fundraiserIds == null)
                {
                     fundraiserIds = await fundraiserRepository.GetFundraiserIdsAsync();
                }
 
                Donation donation = new Donation
                {
                    DonorId = RandomItem(donorIds),
                    FundraiserId = RandomItem(fundraiserIds),
                    Amount = 500,
                    DonationDate = DateTimeOffset.Now
                };
                donationRepository.AddDonation(donation);
                await donationRepository.SaveChangesAsync();
                await fundraiserRepository.UpdateFundTotalAsync(donation.FundraiserId, donation.Amount);
                logger.LogWarning($"Donation added for {donation.FundraiserId} by {donation.DonorId}");
            }
            //return Task.CompletedTask;
        }


        private Guid RandomItem(IEnumerable<Guid> guids)
        {
            return guids
                    .Skip(guids.Count().RandomNumberLessThan())
                    .First();
         }

        int CalculateInterval(int value)
        {
            return (60 / value) * 1000;
        }

  
        public void Dispose()
        {
            if (timer != null)
            {
                timer.Close();
                timer.Dispose();
            }
        }
    }
}
