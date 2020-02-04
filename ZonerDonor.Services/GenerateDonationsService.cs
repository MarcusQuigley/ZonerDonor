using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
 using System.Threading;
using System.Threading.Tasks;
using  Timers = System.Timers;
using ZonerDonor.Core.Models;
//using System.Threading;
using ZonerDonor.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ZonerDonor.Services
{
    public class GenerateDonationsService : IHostedService, IDisposable
    {
        readonly Timers.Timer timer;
          IDonationRepository donationRepository;
          IDonorRepository donorRepository;
          IFundraiserRepository fundraiserRepository;
        readonly IServiceScopeFactory scopeFactory;
        private int numberPerMinute = 2;
        ILogger<GenerateDonationsService> logger;

        public GenerateDonationsService(
            IServiceScopeFactory scopeFactory,
            ILogger<GenerateDonationsService> logger)
        {

            this.scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            timer = new Timers.Timer(CalculateInterval(NumberPerMinute));
            timer.Elapsed  += Timer_Elapsed;
         }
 
        private async void Timer_Elapsed(object sender, Timers.ElapsedEventArgs e)
        {
          await  CreateDonation();
        }
        private async Task CreateDonation()
        {
            using(var scope = scopeFactory.CreateScope())
            {
                donorRepository = scope.ServiceProvider.GetService<IDonorRepository>();
                fundraiserRepository = scope.ServiceProvider.GetService<IFundraiserRepository>();
                donationRepository = scope.ServiceProvider.GetService<IDonationRepository>();
            }
            
            var donor = await donorRepository.GetRandomDonorAsync();
            var fundraiser = await fundraiserRepository.GetRandomFundraiserAsync();
            Donation donation = new Donation
            {
                DonorId = donor.Id,
                FundraiserId = fundraiser.Id,
                Amount = 500,
                DonationDate = DateTimeOffset.Now
            };
            donationRepository.AddDonation(donation);
            logger.LogWarning($"Donation added for {donation.FundraiserId} by {donation.DonorId}");
            //return Task.CompletedTask;
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
    }
}
