using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<FactoryContext>(options
    => options.UseMySQL(builder.Configuration.GetConnectionString("FactoryDatabase")));
builder.Services.AddSwaggerGen();

//�]�w CROS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        _ = builder
            .AllowAnyOrigin() // ���\����ӷ�
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

//�]�wCROS
app.UseRouting();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger(); // �� Swagger UI �i��
    app.UseSwaggerUI(); // �]�w Swagger UI �����|
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
