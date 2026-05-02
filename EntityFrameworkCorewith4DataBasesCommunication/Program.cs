using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dbconnect;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Repositories;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Services;
using EntityFrameworkCorewith4DataBasesCommunication.Dbconnect;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register your context class and pointing to your connection string.
//you should tell to ef core this context class is pointing to this database.
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCodeFirstApproachDatabase")));
builder.Services.AddDbContext<OrdersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderCodeFirstApproachDatabase")));
builder.Services.AddDbContext<DepartmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DepartmentCodeFirstApproachDatabase")));



builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
builder.Services.AddScoped<IOrdersRepository,OrdersRepository>();
builder.Services.AddScoped<IOrdersService,OrderService>();

//----------------------------------------------------------------------------
//-----------------------------------------------------------------------------

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
