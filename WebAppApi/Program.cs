using Microsoft.EntityFrameworkCore;
using WebAppApi.Services.Employees;
using WebAppApi.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesDb")));

builder.Services.AddScoped<IEmployeesService, SqlEmployeesService>();
//builder.Services.AddSingleton<IEmployeesService, MockEmployeesService>();

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