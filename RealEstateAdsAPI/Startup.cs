using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealEstateAds.Dal.Demo;
using RealEstateAds.Dal.Demo.Repositories.AdsList;

namespace RealEstateAdsAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder.AllowAnyOrigin()
									.AllowAnyHeader()
									.AllowAnyMethod());
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			var connectionString = @"Data Source=(LocalDb)\RealEstateAds;Database=Demo;Trusted_Connection=True;";
			services.AddDbContext<DemoContext>(c => c.UseSqlServer(connectionString, x => x.MigrationsAssembly("RealEstateAdsAPI")));

			services.AddScoped<IAdsListItemsRepository, AdsListItemsRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			// Shows UseCors with CorsPolicyBuilder.
			app.UseCors("AllowSpecificOrigin");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
