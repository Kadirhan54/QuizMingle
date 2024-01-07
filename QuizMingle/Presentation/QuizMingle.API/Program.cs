using Microsoft.EntityFrameworkCore;
using QuizMingle.API;
using QuizMingle.API.Services;
using QuizMingle.Application;
using QuizMingle.Persistence.Context;
using QuizMingle.Persistence.Service;
using StudyTimer.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IQuizCreateCounter1, QuizCreateCounter1>;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //dikkat
app.UseAuthorization();   

app.MapControllers();

app.Run();
