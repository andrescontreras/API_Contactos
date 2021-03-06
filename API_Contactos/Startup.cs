﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Cors;

using Microsoft.EntityFrameworkCore;
using API_Contactos.Models;

namespace API_Contactos
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
			services.AddCors();

			services.Configure<IISOptions>(options =>
			{
				options.ForwardClientCertificate = false;
			});

			services.AddDbContext<PublicacionContext>(opt =>
				opt.UseInMemoryDatabase("TodoList"));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseCors(builder =>
			builder.WithOrigins("http://localhost:4200", "http://afcserver.tk", "https://as-networking-fe.azurewebsites.net").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

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
