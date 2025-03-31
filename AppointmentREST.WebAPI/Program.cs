using AppointmentREST.BusinessLogic.AppExtensions;
using AppointmentREST.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContexts(builder.Configuration);
MapperRegistration.AddTinyMapper(builder.Services);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddCorsPolicy(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomRateLimiter(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.MapControllers();

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseRateLimiter();

app.Run();