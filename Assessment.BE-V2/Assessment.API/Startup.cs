using Assessment.Domain.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Assessment.Domain.Contexts;
using Microsoft.AspNetCore.Identity;
using Assessment.Domain.EF.Contexts;
using Assessment.Domain.Services.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Assessment.Domain.Services.Identity;


namespace Assessment.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDatabaseDependencies(Configuration);
			services.AddScoped<DomainContext, DomainContext>();
			services.AddSwaggerGen();
			services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();
			services.AddScoped<IIdentityService, IdentityService>();

			services.AddDbContext<AssessmentDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("Default")));

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
			).AddEntityFrameworkStores<AssessmentDbContext>().AddDefaultTokenProviders();

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
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

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
