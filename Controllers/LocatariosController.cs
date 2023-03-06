using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using DesafioBiopark.Config;
using DesafioBiopark.Config.Queries;
using DesafioBiopark.Model;
using DesafioBiopark.Model.Migrations;

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

    [HttpGet("/locatarios/{id}")]
    public async Task<IActionResult> LocatarioId(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = LocatariosQuery.LocatarioId(id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/locatarios/novo")]
    public async Task<IActionResult> NovoLocatario([FromBody] LocatariosMigration model)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = LocatariosQuery.NovoLocatario(model);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut("/locatarios/{id}")]
    public async Task<IActionResult> EditarLocatario([FromBody] LocatariosMigration model, int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = LocatariosQuery.EditarLocatario(model, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("/locatarios/{id}/ativar")]
    public async Task<IActionResult> AtivarLocatario(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = LocatariosQuery.AtivarDesativarLocatario(true, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("/locatarios/{id}/desativar")]
    public async Task<IActionResult> DesativarLocatario(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            var validacao = conn.Query($"SELECT * FROM Contratos WHERE locatarioId = {id} AND isActive={true}");
            if (validacao.Count() > 0)
                return StatusCode(500, "Cadastro com contrato de aluguel ativo!");
            string query = LocatariosQuery.AtivarDesativarLocatario(false, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}