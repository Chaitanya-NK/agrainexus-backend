using agrainexus.Business.IServices;
using agrainexus.Business.Services;
using agrainexus.Data.IRepositories;
using agrainexus.Data.Repositories;
using agrainexus.TokenGeneration.TokenImplementation;
using agrainexus.TokenGeneration.TokenInterface;

var builder = WebApplication.CreateBuilder(args);

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IFarmRepository, FarmRepository>();
builder.Services.AddSingleton<IFarmService, FarmService>();
/*builder.Services.AddSingleton<IOutsideTemperatureRepository, OutsideTemperatureRepository>();
builder.Services.AddSingleton<IOutsideTemperatureService, OutsideTemperatureService>();*/
builder.Services.AddSingleton<ILoginSessionRepository, LoginSessionRepository>();
builder.Services.AddSingleton<ILoginSessionService, LoginSessionService>();
builder.Services.AddSingleton<IToken, Token>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();

string? connectionString = configuration.GetConnectionString("ConnectionString");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
