

using Microsoft.EntityFrameworkCore;
using TuvTurk.Business.Abstract;
using TuvTurk.Business.Concrete;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.DataAccess.Concrete.EntityFramework.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TuvTurkDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TuvTurkDatabaseContext")));

builder.Services.AddScoped<IAppointmentDal, EfAppointmentRepository>();
builder.Services.AddScoped<ISlotDal, EfSlotRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
builder.Services.AddScoped<ISlotService, SlotManager>();

builder.Services.AddControllers();
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
