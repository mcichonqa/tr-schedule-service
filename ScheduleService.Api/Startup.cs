using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScheduleService.Api.Mapper.Profiles;
using ScheduleService.Entity;
using ScheduleService.Repository;
using System.Text.Json.Serialization;

namespace ScheduleService.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScheduleService.Api", Version = "v1" });
            });

            services.AddRouting(routeOption => routeOption.LowercaseUrls = true);

            services.AddCors(options =>
                options.AddPolicy(
                    "CorsPolicy",
                    b => b.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .Build()));

            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            //    {
            //        options.Authority = Configuration.GetValue<string>("AuthorityService");
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false,
            //            ClockSkew = TimeSpan.FromSeconds(1)
            //        };
            //    });

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", h => {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    config.ConfigureEndpoints(context);
                });
            });

            services.AddDbContext<ScheduleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ScheduleDb")));
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddAutoMapper(typeof(MeetingProfile));

            services
                .AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScheduleService.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}