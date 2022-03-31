using Microsoft.EntityFrameworkCore;
using TimeRegApi.Data;
using TimeRegApi.UI.DataAccessUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TRDbContext>(options => {
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSqlite("Filename=./Todo.db");
});

builder.Services.AddScoped<TRDbContext>();
builder.Services.AddScoped<IProjectsDataAccess, ProjectsDataAccess>();
builder.Services.AddScoped<IEmployeesDataAccess, EmployeesDataAccess>();
builder.Services.AddScoped<ITimeReportsDataAccess, TimeReportsDataAccess>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Time-Reg-Api",
        Version = "v1"
    });
});

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
