using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Services.AccessLogs;
using UniversityOfNottinghamAPI.Services.DatabaseManagement;
using UniversityOfNottinghamAPI.Services.DeviceManagement;
using UniversityOfNottinghamAPI.Services.Document;
using UniversityOfNottinghamAPI.Services.NotificationManagement;
using UniversityOfNottinghamAPI.Services.StorageManagement;
using UniversityOfNottinghamAPI.Services.UserManagement;

namespace UniversityOfNottinghamAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins(_configuration.GetConnectionString("Angular")) 
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("SQL")));
            services.AddHttpClient();


            services.AddScoped<IAccessLogsService, AccessLogsService>();
            services.AddScoped<IDatabaseManagementService,DatabaseManagementService>();
            services.AddScoped<IDeviceManagementService, DeviceManagementService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<INotificationManagementService, NotificationManagementService>();
            services.AddScoped<IStorageManagementService, StorageManagementService>();
            services.AddScoped<IUserManagementService, UserManagementService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowSpecificOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }
    }
}
