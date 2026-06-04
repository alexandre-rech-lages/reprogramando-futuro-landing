using ReprogramandoFuturo.WebApi.EndPoints;
using ReprogramandoFuturo.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISheetDbService, SheetDbService>();

const string CorsPolicy = "FrontendPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy =>
    {
        // Lê do appsettings / variável de ambiente "FrontendUrl"
        var frontendUrl = builder.Configuration["FrontendUrl"] ?? "http://localhost:4200";
        policy.WithOrigins(frontendUrl)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(CorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapMethods("/health", new[] { "HEAD" }, () =>
{
    // Sem corpo na resposta (HEAD)
    return Results.Ok();
});

app.MapPost("/api/enrollment", EnrollmentEndPoint.HandleEnrollmentAsync)
.WithName("CreateEnrollment");

app.Run();
