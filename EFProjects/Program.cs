using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");


using var connection = new SqlConnection(connectionString);

connection.Open();

void UpdateCarPrice(int carId, decimal newPrice)
{
    var sqlQuery = "UPDATE Cars SET Price = @NewPrice WHERE Id = @CarId";
    
    connection.Query(sqlQuery, new {NewPrice = newPrice, CarId = carId });
}

void DeleteCarById(int carId)
{
    var sqlQuery = "DELETE FROM Cars WHERE Id = @CarId";
    
    connection.Query(sqlQuery, new {CarId = carId });
}

void GetAllCars()
{
    var sqlQuery = "SELECT * FROM Cars";
    
    var cars = connection.Query(sqlQuery);
}

void GetAllCarsByBrand(string brand)
{
    var sqlQuery = "SELECT * FROM Cars WHERE Brand = @BrandName";
    
    var cars = connection.Query(sqlQuery, new {BrandName = brand});
}