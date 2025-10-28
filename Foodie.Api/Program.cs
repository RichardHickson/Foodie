using Foodie.Api.Routes;
using Foodie.Core.Interfaces.Repositories;
using Foodie.Core.Repositories;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DbDataSource>(_ => 
{
    var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=localhost;Username=postgres;Password=Robotyt12;Database=foodie;Include Error Detail=True;");
    return dataSourceBuilder.Build();
});
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>(p =>
{
    var dataSource = p.GetRequiredService<DbDataSource>();
    return new IngredientRepository(dataSource.OpenConnection());
});
builder.Services.AddScoped<IUserRepository, UserRepository>(p =>
{
    var dataSource = p.GetRequiredService<DbDataSource>();
    return new UserRepository(dataSource.OpenConnection());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddRoutes();

app.Run();
