/*
 * Copyright 2016-2018 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan
 * Date: 2018-10-29
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApplication.Data;
using TodoApplication.Data.Model;
using TodoApplication.Services;

namespace TodoApplication
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
			var servicesConfigurationSection = this.Configuration.GetSection("Services");

			foreach (var service in servicesConfigurationSection.GetChildren())
			{
				var serviceType = Type.GetType(service["serviceType"]);
				var implementationType = Type.GetType(service["implementationType"]);

				if (serviceType == null)
				{
					throw new InvalidOperationException($"Unable to locate service type: {service["serviceType"]}");
				}

				if (implementationType == null)
				{
					throw new InvalidOperationException($"Unable to locate implementation type: {service["implementationType"]}");
				}

				services.AddScoped(serviceType, implementationType);
			}

			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TodoApplicationConnection")));
			services.AddIdentity<ApplicationUser, ApplicationRole>()
					.AddEntityFrameworkStores<ApplicationDbContext>()
					.AddRoleManager<ApplicationRoleManager>()
					.AddSignInManager<ApplicationSignInManager>()
					.AddUserManager<ApplicationUserManager>()
					.AddRoleStore<ApplicationRoleStore>()
					.AddUserStore<ApplicationUserStore>()
					.AddDefaultTokenProviders();

			services.AddScoped<SignInManager<ApplicationUser>, ApplicationSignInManager>();
			services.AddScoped<UserManager<ApplicationUser>, ApplicationUserManager>();
			services.AddScoped<RoleManager<ApplicationRole>, ApplicationRoleManager>();
			services.AddScoped<RoleStore<ApplicationRole, ApplicationDbContext, Guid, ApplicationUserRole, ApplicationRoleClaim>, ApplicationRoleStore>();
			services.AddScoped<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationUserToken, ApplicationRoleClaim>, ApplicationUserStore>();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			// add mvc
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
