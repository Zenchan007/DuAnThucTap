using DuAnThucTap.Data;
using DuAnThucTap.Models;
using DuAnThucTap.Reponsitories;
using DuAnThucTap.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.ImplicitlyValidateChildProperties = true; // Bật validate cả các thuộc tính con của đối tượng
    //Tự động đăng ký tất cả validate trong ứng dụng
    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()); // 
});
//builder.Services.AddTransient<IValidator<CustomerModel>, CustomerValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICustomerReponsitory, CustomerReponsitory>();
//builder.Services.AddTransient<CustomerValidator>();
builder.Services.AddDbContext<CustomerContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("DBThucTap"));
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
