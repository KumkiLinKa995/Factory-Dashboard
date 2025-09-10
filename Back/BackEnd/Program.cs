using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<FactoryContext>(options
    => options.UseMySQL(builder.Configuration.GetConnectionString("FactoryDatabase")));
builder.Services.AddSwaggerGen();

//設定 CROS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        _ = builder
            .AllowAnyOrigin() // 允許任何來源
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

//設定CROS
app.UseRouting();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger(); // 使 Swagger UI 可用
    app.UseSwaggerUI(); // 設定 Swagger UI 的路徑
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
