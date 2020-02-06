using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using ZonerDonor.Hubs;
using ZonerDonor.Services;

namespace ZonerDonor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FundContext>(options =>
            {
                var connString = Configuration.GetConnectionString("DbConnection");
                options.UseSqlServer(connString);
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddScoped<IFundraiserRepository, MockFundraiserRepository>();
            //services.AddScoped<IDonorRepository, MockDonorRepository>();
            //services.AddScoped<IDonationRepository, MockDonationRepository>();
            services.AddScoped<IFundraiserRepository, FundraiserRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            if (Configuration.GetSection("AutoDonations").GetValue<bool>("GenerateDonations"))
            {
                services.AddHostedService<GenerateDonationsService>();
            }

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddSignalR(configure => configure.EnableDetailedErrors=true);
          
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ZonorHub>("/zonorhub");
            });
            logger.LogInformation("Configuring Pipeline");
        }
    }
}
