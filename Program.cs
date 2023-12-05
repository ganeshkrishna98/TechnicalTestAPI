using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechnicalTestAPI.Database;
using TechnicalTestAPI.ModelMapping.AccessLogs;
using TechnicalTestAPI.ModelMapping.DatabaseManagement;
using TechnicalTestAPI.ModelMapping.DeviceManagement;
using TechnicalTestAPI.ModelMapping.Document;
using TechnicalTestAPI.ModelMapping.NotificationManagement;
using TechnicalTestAPI.ModelMapping.StorageManagement;
using TechnicalTestAPI.ModelMapping.UserManagement;
using TechnicalTestAPI.Services.AccessLogs;
using TechnicalTestAPI.Services.Authentication;
using TechnicalTestAPI.Services.Common;
using TechnicalTestAPI.Services.DatabaseManagement;
using TechnicalTestAPI.Services.DeviceManagement;
using TechnicalTestAPI.Services.Document;
using TechnicalTestAPI.Services.NotificationManagement;
using TechnicalTestAPI.Services.StorageManagement;
using TechnicalTestAPI.Services.UserManagement;

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