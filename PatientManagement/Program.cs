using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<HospitalDBContect>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PatientAppDBConnection"));
}
);
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
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
