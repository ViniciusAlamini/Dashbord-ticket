using ApiDashboard.DB;
using ApiDashboard.Interface;
using ApiDashboard.Models;
using ApiDashboard.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DashboardContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ICrudRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ICrudRepository<Ticket>, TicketRepository>();
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<ICrudRepository<Modulo>, ModuloRepository>();
builder.Services.AddScoped<ModuloRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
