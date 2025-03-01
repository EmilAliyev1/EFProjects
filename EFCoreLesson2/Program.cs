using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");

using var connection = new SqlConnection(connectionString);

connection.Open();