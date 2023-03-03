using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Configuration;

namespace DesafioBiopark.Config;

public class DapperConn
{
    public static MySqlConnection Conn()
    {
        string Server = System.Configuration.ConfigurationManager.AppSettings["ServerName"];
        string Port = System.Configuration.ConfigurationManager.AppSettings["Port"];
        string Database = System.Configuration.ConfigurationManager.AppSettings["Database"];
        string UserId = System.Configuration.ConfigurationManager.AppSettings["UserName"];
        string Password = System.Configuration.ConfigurationManager.AppSettings["UserPass"];
        
        MySqlConnection connection = new MySqlConnection($"Server={Server};Port={Port};Database={Database};User Id={UserId};Password={Password};");
        
        return connection;
    }
}