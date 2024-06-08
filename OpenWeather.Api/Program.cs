using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using OpenWeather.Api.Middlewares;
using OpenWeather.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDIConfiguration(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyHeader();
    });
});

builder.Services.AddExceptionHandler(options =>
{
    options.ExceptionHandler = GlobalExceptionHandler.Handle;
    options.AllowStatusCode404Response = true;
});

builder.Services.AddRouting();

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Acme Products Api",
        Version = "v1",
        Description = "Api for product management",
        Contact = new OpenApiContact
        {
            Name = "Acme Ltda.",
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/mit"),
        },
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
