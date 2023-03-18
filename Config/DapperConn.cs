using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Configuration;

namespace DesafioBiopark.Config;

public class DapperConn
{
    public static MySqlConnection Conn()
    {
        IConfiguration AppSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables()
            .Build();

        IConfigurationSection ConnectionStrings = AppSettings.GetSection("ConnectionStrings");

        string Server = ConnectionStrings["ServerName"];
        string Port = ConnectionStrings["Port"];
        string Database = ConnectionStrings["Database"];
        string UserId = ConnectionStrings["UserName"];
        string Password = ConnectionStrings["UserPass"];
        
        MySqlConnection connection = new MySqlConnection($"Server={Server};Port={Port};Database={Database};User Id={UserId};Password={Password};");
        
        return connection;
    }
}