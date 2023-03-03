using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBiopark.Model.Migrations;

public class ContratoMigration
{
    [Key]
    public int id { get; set; }
    public DateTime dtInicio { get; set; }
    public double valorAluguelMen { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool isActive { get; set; }
    
    [Required]
    public LocatariosMigration locatario { get; set; }
    public int locatarioId { get; set; }
    public ApartamentosMigration apartamento { get; set; }
    public int apartamentoId { get; set; }
}