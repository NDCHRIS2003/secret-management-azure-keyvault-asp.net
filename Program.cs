using Azure.Identity;
using EmployeeRecordMvcAPI.Data;
using EmployeeRecordMvcAPI.Repository;
using EmployeeRecordMvcAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(opt =>
//    {
//        opt.Audience = $"{builder.Configuration.GetValue<string>("AppReg:ResourceId")}";
//        opt.Authority = $"{builder.Configuration["AppReg:InstanceId"]}{builder.Configuration["AppReg:TenantId"]}";
//    });

var keyVaultUrl = new Uri(builder.Configuration.GetValue<string>("KeyVaultUrl"));
var defaultAzureCredential = new DefaultAzureCredential();
builder.Configuration.AddAzureKeyVault(keyVaultUrl, defaultAzureCredential);
// azurePostgreSqlConnectionString is the name of our connection string
// in Azure KeyVault
var connectionString = builder.Configuration.GetValue<string>("azurePostgreSqlConnectionString");
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
