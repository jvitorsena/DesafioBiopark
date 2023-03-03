using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBiopark.Model.Migrations;

public class EdificiosMigration
{
    [Key, ForeignKey("edificiosId")]
    public int id { get; set; }
    public string nome { get; set; }
    public string locadora { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
    [DefaultValue(1)]
    public bool? isActive { get; set; }
}