using EntityFramework;
using IOMBBA_System.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Objects.Interfaces;
using Objects.Models;

namespace IOMBBA_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });
            services.AddDbContextPool<DbContextClass>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            // Dependency injection for interfaces.
            services.AddScoped<ICompetition, CompetitionRepository>();
            services.AddScoped<IFixture, FixtureRepository>();
            services.AddScoped<IGameplayStat, GameplayStatRepository>();
            services.AddScoped<IMember, MemberRepository>();
            services.AddScoped<ITeam, TeamRepository>();








            // CORS policy - allow all to access.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                  builder =>
                  {
                      builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
                  });
            });
            //services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAny");

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
