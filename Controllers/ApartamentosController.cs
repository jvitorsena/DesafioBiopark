using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using DesafioBiopark.Config;
using DesafioBiopark.Config.Queries;
using DesafioBiopark.Model;
using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Controllers;

public class ApartamentosController : ControllerBase
{
    private readonly ILogger<ApartamentosController> _logger;

    public ApartamentosController(ILogger<ApartamentosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/apartamentos/todos")]
    public async Task<IActionResult> TodosApartamentos()
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ApartamentosQuery.TodosApartamentos();
            var apartamentos = conn.Query(query);
            return Ok(apartamentos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("/apartamentos/{id}")]
    public async Task<IActionResult> ApartamentoId(int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ApartamentosQuery.ApartamentoId(id);
            var apartamentos = conn.Query(query);
            return Ok(apartamentos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/apartamentos/novo")]
    public async Task<IActionResult> NovoApartamento([FromBody] ApartamentosMigration model)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ApartamentosQuery.NovoApartamento(model);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("/apartamentos/{id}")]
    public async Task<IActionResult> EditarApartamento([FromBody] ApartamentosMigration model, int id)
    {
        try
        {
            MySqlConnection conn = DapperConn.Conn();
            string query = ApartamentosQuery.EditarApartamento(model, id);
            var edificios = conn.Query(query);
            return Ok(edificios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/apartamentos/{id}/ativar")]
    public async Task<IActionResult> AtivarApartamento(int id)
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
    
    [HttpPost("/apartamentos/{id}/desativar")]
    public async Task<IActionResult> DesativarApartamento(int id)
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