using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DapperLastLesson;

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");

using var connection = new SqlConnection(connectionString);

connection.Open();

void InsertCarAndOwner(string brand, string model, int year, decimal price, string ownerName)
{
    string sqlQuery = @"
        DECLARE @InsertedCar TABLE (Id INT);

        INSERT INTO Cars (Brand, Model, Year, Price) 
        OUTPUT INSERTED.Id INTO @InsertedCar
        VALUES (@Brand, @Model, @Year, @Price);
        
        INSERT INTO Owners (Name, CarId) 
        VALUES (@OwnerName, (SELECT Id FROM @InsertedCar));";

    connection.Execute(sqlQuery, new { Brand = brand, Model = model, Year = year, Price = price, OwnerName = ownerName });
} // nemnogo kalxozno, no soydet, v EF budet lucse, obesayu )

// InsertCarAndOwner("BMW", "Ford", 2020, 10000, "Emil");

void UpdateOwner(string ownerName, int carId)
{
    var sqlQuery = @"UPDATE Owners SET Name = @NewOwner WHERE CarId = @CarId";
    connection.Execute(sqlQuery, new {NewOwner = ownerName, CarId = carId});
}

// UpdateOwner("Elvin", 1);

void DeleteCarAndOwner(int carId)
{
    var sqlQuery = @"
                   DELETE FROM Owners WHERE CarId = @CarId
                   DELETE FROM Cars WHERE Id = @CarId";
    connection.Execute(sqlQuery, new {CarId = carId});
}

// DeleteCarAndOwner(1);

List<CarWithOwner> GetCarsWithOwners()
{
    string sqlQuery = @"
            SELECT c.Id, c.Brand, c.Model, c.Year, c.Price, o.Name AS OwnerName 
            FROM Cars c
            INNER JOIN Owners o ON c.Id = o.CarId";
    return connection.Query<CarWithOwner>(sqlQuery).AsList();
}


// List<CarWithOwner> carsWithOwner = GetCarsWithOwners();
//
// foreach (var car in cars)
// {
//     Console.WriteLine(car.Brand + " " + car.Model + " " + car.Year + " " + car.Price + " " + car.OwnerName);
// }


List<Car> GetCarsByOwner(string ownerName)
{
    string sql = @"
            SELECT c.Id, c.Brand, c.Model, c.Year, c.Price 
            FROM Cars c
            INNER JOIN Owners o ON c.Id = o.CarId
            WHERE o.Name = @OwnerName";
    return connection.Query<Car>(sql, new { OwnerName = ownerName }).AsList();
}


// List<Car> cars = GetCarsByOwner("Elvin");
//
// foreach (var car in cars)
// {
//     Console.WriteLine(car.Brand + " " + car.Model + " " + car.Year + " " + car.Price);
// }