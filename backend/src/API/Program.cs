using API.DependencyInjection;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

// Add services to the container.
builder.Services.AddHostedService<My1BackgroundService>();
builder.Services.AddHostedService<My2BackgroundService>();
builder.Services.AddHostedService<My3BackgroundService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper();
builder.Services.AddFluentValidation();
builder.Services.AddDbContext(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
