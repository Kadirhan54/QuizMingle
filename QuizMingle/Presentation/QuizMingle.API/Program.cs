using Microsoft.EntityFrameworkCore;
using QuizMingle.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetSection("Team3PostgreSQLDB").Value;

builder.Services.AddDbContext<QuizMingleDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
