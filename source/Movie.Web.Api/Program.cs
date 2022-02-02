using Movie.Data.Engine.Interface;
using Movie.Data.Engine.Model;
using Movie.Operation.Engine.EngineInterface;
using Movie.Operation.Engine.EngineModel;
using Movie.Operation.Engine.Validator.Class;
using Movie.Operation.Engine.Validator.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("./appsettings.json").Build();
var connectionString = configuration.GetConnectionString("SqlDbContext");
builder.Services.AddSingleton<ISqlConnect>(_ => new SqlConnect(connectionString));
builder.Services.AddSingleton<IDataProcessEngine, DataProcessEngine>();
builder.Services.AddSingleton<IDataProcessRepository>(_ => new DataProcessRepository(_.GetService<ISqlConnect>()));
builder.Services.AddSingleton<IDataReadRepository>(_ => new DataReadRepository(_.GetService<ISqlConnect>()));
builder.Services.AddTransient<IMovieValidation, MovieValidation>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


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
