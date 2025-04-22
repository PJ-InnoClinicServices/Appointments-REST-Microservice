using AppointmentREST.BusinessLogic.AppExtensions;
using AppointmentREST.DataAccess;
using AppointmentREST.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), npgsqlOptions =>
    {
        npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_Appointments");
    }));

// Automapper / TinyMapper
MapperRegistration.AddTinyMapper(builder.Services);

// Custom services
builder.Services.AddRepositories();
builder.Services.AddServices();

// Misc services
builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomRateLimiter(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Container")
{
    app.UseSwagger(options => options.OpenApiVersion =
        Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.ApplyMigrations();
}

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseRateLimiter();

app.MapControllers();

app.Run();