using Assessment.Core;
using Assessment.Core.Services.Books;
using Assessment.Core.Services.IdentityService;
using Assessment.Core.Services.Subscribtions;
using Assessment.Core.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.API
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
			services.AddControllers();

			services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();
			services.AddScoped<ISubscriptionService, SubscriptionService>();
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<IIdentityService, IdentityService>();

			services.AddDbContext<ApplicationDBContext>(x => x.UseSqlite(Configuration.GetConnectionString("Default")));
			//If you are using sqlServer
			//services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));

			services.AddIdentity<IdentityUser, IdentityRole>(opt =>
			{
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequiredLength = 4;

				opt.User.RequireUniqueEmail = true;
				opt.SignIn.RequireConfirmedEmail = false;
			}
			).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();


			services.AddAuthentication(cfg =>
			{
				cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{

				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
					ValidIssuer = Configuration["Token:Issuer"],
					ValidateIssuer = true,
					ValidateAudience = false,
				};
			});	

			services.AddAuthorization();
			services.AddSwaggerGen();
		
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(options =>
			{
				options.AllowAnyHeader();
				options.AllowAnyMethod();
				options.AllowAnyOrigin();
				options.SetPreflightMaxAge(TimeSpan.FromMinutes(20));
			});

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imagine Bookstore API");
			});
		}
	}
}
