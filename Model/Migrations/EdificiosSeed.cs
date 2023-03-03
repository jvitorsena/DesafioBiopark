using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Model.Migrations;

public class EdificiosSeed
{
    public static readonly List<EdificiosMigration> Edificios = new List<EdificiosMigration>
    {
        new EdificiosMigration
            { id = 1, locadora = "Biopark", nome = "Edificio primavera", createdAt = DateTime.Now, updatedAt = DateTime.Now }
    };
}