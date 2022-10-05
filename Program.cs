using MongoDB.Driver;
using webapi6.ItemMember;
using webapi6.Settings;


var builder = WebApplication.CreateBuilder(args);

 

// Add services to the container.

builder.Services.AddControllers();


//Registering mongoClient
builder.Services.AddSingleton<IMongoClient>(ServiceProvider => {
    var settings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IItemRepository,ItemRepository>();


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
