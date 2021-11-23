using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting; 
using Microsoft.IdentityModel.Tokens;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Repositories;
using PM.API.Domain.Services;
using PM.API.Extensions;
using PM.API.Persistence.Repositories;
using PM.API.Services;
using System; 
using System.IO; 
using System.Text;
using System.Threading.Tasks;

namespace PM.API
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
            services.AddHttpContextAccessor();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DelayFilter));
            })
            .AddNewtonsoftJson();
            // Use microsoft DistributedMemoryCache
            services.AddDistributedMemoryCache();
            // if you want to use Redis cache
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "[yourconnection string]";
            //    option.InstanceName = "[your instance name]";
            //});
            services.AddCustomSwagger();
            services.AddControllers();
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse; 
            });
            services.AddCors();
            services.AddDbContext<PMContext>();
            services.AddAutoMapper(typeof(Startup));
            // ..... 
            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);
            // services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IEmailService, EmailService>();
            // Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

            

           
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddHttpClient();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var accService = context.HttpContext.RequestServices.GetRequiredService<IAccountService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = accService.GetById(userId).Result;
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomSwagger(appSettings);

            app.UseStaticFiles();
            string fileFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles")),
                RequestPath = "/Files"
            });
            app.UseRouting();
             
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 

        }
    }
}
