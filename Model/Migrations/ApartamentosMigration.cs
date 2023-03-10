using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBiopark.Model.Migrations;

public class ApartamentosMigration
{
    [Key, ForeignKey("apartamentoId")]
    public int id { get; set; }
    public int numero { get; set; }
    public int andar { get; set; }
    public bool? alugado { get; set; } = false;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool isActive { get; set; }
    
    [Required]
    public EdificiosMigration edificios { get; set; }
    public int edificiosId { get; set; }
    
}