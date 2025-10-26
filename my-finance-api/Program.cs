using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using my_finance_application;
using my_finance_infra;
using my_finance_infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MyFinanceDbContext>(options =>
{
    var connStr = configuration.GetConnectionString("DefaultConnection")
                  ?? "Host=localhost;Database=myfinance;Username=postgres;Password=postgres";
    options.UseNpgsql(connStr);
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyFinance API",
        Version = "v1",
        Description = "Personal finance management API 💰",
    });
});
builder.Services.AddApplication();

// Infrastructure (DbContext, repos, integrações)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFinance API v1");
        options.RoutePrefix = string.Empty; // Abre o Swagger direto em "/"
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
