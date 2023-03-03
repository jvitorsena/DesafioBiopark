using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using DesafioBiopark.Config;
using DesafioBiopark.Config.Queries;
using DesafioBiopark.Model;
using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Controllers;

public class ContratosController : ControllerBase
{
    private readonly ILogger<ContratosController> _logger;

    public ContratosController(ILogger<ContratosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/contratos/todos")]
    public async Task<IActionResult> TodosContratos()
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.TodosContratos();
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("/contratos/{id}")]
    public async Task<IActionResult> ContratoId(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.ContratoId(id);
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/contratos/novo")]
    public async Task<IActionResult> NovoContrato([FromBody] ContratoMigration model)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.NovoContrato(model);
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("/contratos/{id}")]
    public async Task<IActionResult> EditarContrato([FromBody] ContratoMigration model, int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.EditarContrato(model, id);
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/contratos/{id}/ativar")]
    public async Task<IActionResult> AtivarContrato(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.AtivarDesativarContrato(true, id);
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }   
    
    [HttpPost("/contratos/{id}/desativar")]
    public async Task<IActionResult> DesativarContrato(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ContratosQuery.AtivarDesativarContrato(false, id);
            var contratos = conn.Query(query);
            return Ok(contratos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
        
}