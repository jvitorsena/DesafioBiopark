using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBiopark.Model.Migrations;

public class LocatariosMigration
{
    [Key, ForeignKey("locatariosId")]
    public int id { get; set; }
    public string nome { get; set; }
    public DateTime dataNasc { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool isActive { get; set; }
}