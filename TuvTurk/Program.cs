

using Microsoft.EntityFrameworkCore;
using TuvTurk.Business.Abstract;
using TuvTurk.Business.Concrete;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.DataAccess.Concrete.EntityFramework.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TuvTurkDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CloudBeaverContext")));

//Services and Dals
builder.Services.AddScoped<IAppointmentDal, EfAppointmentRepository>();
builder.Services.AddScoped<ISlotDal, EfSlotRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
builder.Services.AddScoped<ISlotService, SlotManager>();

builder.Services.AddScoped<ICityDal, EfCityRepository>();
builder.Services.AddScoped<ICityService, CityManager>();

builder.Services.AddScoped<ICustomerDal, EfCustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();

builder.Services.AddScoped<IStationDal, EfStationRepository>();
builder.Services.AddScoped<IStationService, StationManager>();

builder.Services.AddScoped<IEnumGroupDal, EfEnumGroupRepository>();
builder.Services.AddScoped<IEnumGroupService, EnumGroupManager>();

builder.Services.AddScoped<IEnumGroupTypeDal, EfEnumGroupTypeRepository>();
builder.Services.AddScoped<IEnumGroupTypeService, EnumGroupTypeManager>();
//end Services and Dals


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
