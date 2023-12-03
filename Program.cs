using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.ModelMapping.AccessLogs;
using UniversityOfNottinghamAPI.ModelMapping.DatabaseManagement;
using UniversityOfNottinghamAPI.ModelMapping.DeviceManagement;
using UniversityOfNottinghamAPI.ModelMapping.Document;
using UniversityOfNottinghamAPI.ModelMapping.NotificationManagement;
using UniversityOfNottinghamAPI.ModelMapping.StorageManagement;
using UniversityOfNottinghamAPI.ModelMapping.UserManagement;
using UniversityOfNottinghamAPI.Services.AccessLogs;
using UniversityOfNottinghamAPI.Services.Authentication;
using UniversityOfNottinghamAPI.Services.Common;
using UniversityOfNottinghamAPI.Services.DatabaseManagement;
using UniversityOfNottinghamAPI.Services.DeviceManagement;
using UniversityOfNottinghamAPI.Services.Document;
using UniversityOfNottinghamAPI.Services.NotificationManagement;
using UniversityOfNottinghamAPI.Services.StorageManagement;
using UniversityOfNottinghamAPI.Services.UserManagement;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Technical Test", Version = "v1" });
});

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
builder.Services.AddHttpClient();

builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddScoped<IAccessLogsService, AccessLogsService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IDatabaseManagementService, DatabaseManagementService>();
builder.Services.AddScoped<IDeviceManagementService, DeviceManagementService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<INotificationManagementService, NotificationManagementService>();
builder.Services.AddScoped<IStorageManagementService, StorageManagementService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();

builder.Services.AddScoped<IAccessLogsModelMapping, AccessLogsModelMapping>();
builder.Services.AddScoped<IDatabaseManagementModelMapping, DatabaseManagementModelMapping>();
builder.Services.AddScoped<IDeviceManagementModelMapping, DeviceManagementModelMapping>();
builder.Services.AddScoped<IDocumentModelMapping, DocumentModelMapping>();
builder.Services.AddScoped<INotificationManagementModelMapping, NotificationManagementModelMapping>();
builder.Services.AddScoped<IStorageManagementModelMapping, StorageManagementModelMapping>();
builder.Services.AddScoped<IUserManagementModelMapping, UserManagementModelMapping>();
#endregion ConfigureServices

var app = builder.Build();

#region Configure

if (app.Environment.IsDevelopment())
{
    app.Urls.Add("https://localhost:7028");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Technical Test V1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

#endregion Configure

app.Run();