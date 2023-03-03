using DesafioBiopark.Model;

namespace DesafioBiopark.Config.Queries;

public class EdificiosQuery
{
    public static string TodosEdificios()
    {
        return "SELECT * FROM Edificios";
    }
    
    public static string EdificioId(int id)
    {
        return $"SELECT * FROM Edificios T0 WHERE T0.id = {id}";
    }

    public static string NovoEdificio(EdificioModel model)
    {
        return $@"INSERT INTO Biopark.Edificios
                (nome, locadora, createdAt, isActive)
                VALUES('{model.nome}', '{model.locadora}', '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}', {model.isActive});";
    }
    public static string EditarEdificio(EdificioModel model, int id)
    {
        string nome = string.IsNullOrEmpty(model.nome) ? "" : $"nome='{model.nome}'";
        string locadora = string.IsNullOrEmpty(model.locadora) ? "" : $"locadora='{model.locadora}'";
        string updatedAt = $"updatedAt='{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'";
        string isActive = $"isActive={model.isActive}";
        return $@"UPDATE Biopark.Edificios
                    SET {nome}, {locadora}, {updatedAt}
                    WHERE id={id};";
    }

    public static string AtivarDesativarEdificio(bool isActive, int id)
    {
        return $@"UPDATE Biopark.Edificios SET isActive={isActive} WHERE id={id}";
    }
}