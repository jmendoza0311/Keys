using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Visionamos.MyKeys.Application.OpenBanking.Services;
using Visionamos.MyKeys.Business.OpenBanking.Interfaces;
using Visionamos.MyKeys.Business.OpenBanking.Rules;
using Visionamos.MyKeys.DataAccess.OpenBanking.Context;
using Visionamos.MyKeys.DataAccess.OpenBanking.Repositories;
using Visionamos.SDK.ApiDocumentation;
using Visionamos.SDK.EFDatabase;
using Visionamos.SDK.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseContext<ManageKeysDbContext>("ManageKeysDbContext");
builder.Services.AddScoped<ICustomerKeyRepository, CustomerKeyRepository>();
builder.Services.AddScoped<IManageKeyService, ManageKeyService>();
builder.Services.AddScoped<IKeyBusinessRules, KeyBusinessRules>();
builder.Services.AddApiDocumentation(false);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ManageKeysDbContext>();
    dbContext.Database.Migrate();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseDatabaseContext<ManageKeysDbContext>();
app.UseApiDocumentation();
app.Run();
