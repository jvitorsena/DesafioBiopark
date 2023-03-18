using System.ComponentModel.DataAnnotations;

namespace DesafioBiopark.Model;

public class EdificioModel
{
    [Required(ErrorMessage = "Name is required !")]
    public string? nome { get; set; }
    public string? locadora { get; set; }
    public DateTime? createdAteeFASDA { get; set; }
    public DateTime? updatedAt { get; set; }
    public bool isActive { get; set; } = true;
}