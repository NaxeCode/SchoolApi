using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// builder.Services.AddDbContext<SchoolContext>(opt => opt.UseInMemoryDatabase("Classes"));
builder.Services.AddSqlite<SchoolContext>("Data Source=School.db");
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
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();