using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Insurance.Data;
using Insurance.Models;
using Insurance.Services;
using System.IO;
using CsvHelper;
using Insurance.Models.InsuranceViewModels;
using Insurance.Data.Auxiliar;
using AutoMapper;

namespace Insurance
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();


            //Seed data
            using (var context = app.ApplicationServices.GetService<ApplicationDbContext>())
            {
                if (env.IsDevelopment())
                {
                   /* context.Database.OpenConnection();

                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON");
                 
                    //seed code here
                    string path = "C:\\Users\\Reynaldo\\Desktop\\playin\\CustomerT.csv";

                    using (TextReader fileReader = System.IO.File.OpenText(path))
                    {
                        Mapper.Initialize(cfg =>
                        {
                            cfg.CreateMap<CustomerViewModel, Customer>()
                             .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.FirstName))
                             .ForMember(dto => dto.Id, conf => conf.MapFrom(ol => ol.CustomerId))                             
                             .ForMember(dto=>dto.PlanType,conf=>conf.Ignore())
                             .ForMember(dto => dto.SalePayments, conf => conf.Ignore()); ;
                                
                            cfg.CreateMap<string, double>().ConvertUsing(Convert.ToDouble);
                            cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                        });
                        var reader = new CsvReader(fileReader);
                        reader.Configuration.RegisterClassMap<CustomerViewModelMap>();
                        var allvalues = reader.GetRecords<CustomerViewModel>();
                        foreach (var item in allvalues)
                        {
                            var x = Mapper.Map<Customer>(item);
                            context.Customers.Add(x);
                            
                        }
                    }
                    
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers OFF");
                    context.SaveChanges();
                    context.Database.CloseConnection();*/
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
