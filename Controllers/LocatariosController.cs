using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using DesafioBiopark.Config;
using DesafioBiopark.Config.Queries;
using DesafioBiopark.Model;

namespace DesafioBiopark.Controllers;

public class LocatariosController : ControllerBase
{
    private readonly ILogger<LocatariosController> _logger;

    public LocatariosController(ILogger<LocatariosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/locatarios/todos")]
    public async Task<IActionResult> TodosLocatarios()
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = LocatariosQuery.TodosLocatarios();
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}