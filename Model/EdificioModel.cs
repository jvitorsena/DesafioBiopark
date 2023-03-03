namespace DesafioBiopark.Model;

public class EdificioModel
{
    public string? nome { get; set; }
    public string? locadora { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
    public bool isActive { get; set; } = true;
}