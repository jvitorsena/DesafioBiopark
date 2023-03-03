using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using DesafioBiopark.Config;
using DesafioBiopark.Config.Queries;
using DesafioBiopark.Model;

namespace DesafioBiopark.Controllers;

[ApiController]
[Route("[controller]")]
public class EdificiosController : ControllerBase
{
    private readonly ILogger<EdificiosController> _logger;

    public EdificiosController(ILogger<EdificiosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/edificios/todos")]
    public async Task<IActionResult> TodosEdificios()
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.TodosEdificios();
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("/edificios/{id}")]
    public async Task<IActionResult> EdificioId(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.EdificioId(id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/edificios/novo")]
    public async Task<IActionResult> NovoEdificio([FromBody] EdificioModel model)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.NovoEdificio(model);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("/edificios/{id}")]
    public async Task<IActionResult> EditarEdificio([FromBody] EdificioModel model, int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.EditarEdificio(model, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/edificios/{id}/ativar")]
    public async Task<IActionResult> AtivarEdificio(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.AtivarDesativarEdificio(true, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("/edificios/{id}/desativar")]
    public async Task<IActionResult> DesativarEdificio(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = EdificiosQuery.AtivarDesativarEdificio(false, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}