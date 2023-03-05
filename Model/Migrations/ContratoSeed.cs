namespace DesafioBiopark.Model.Migrations;

public class ContratoSeed
{
    public static readonly List<ContratoMigration> Contratos = new List<ContratoMigration>
    {
        new ContratoMigration
        {
            id = 1, apartamentoId = 1, locatarioId = 1, createdAt = DateTime.Now, updatedAt = DateTime.Now, valorAluguelMen = 600,
            isActive = true
        }, 
        new ContratoMigration
        {
            id = 2, apartamentoId = 5, locatarioId = 5, createdAt = DateTime.Now, updatedAt = DateTime.Now, valorAluguelMen = 600,
            isActive = true
        },
    };
}