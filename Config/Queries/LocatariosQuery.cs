using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Config.Queries;

public class LocatariosQuery
{
    public static string TodosLocatarios()
    {
        return "SELECT * FROM Locatarios T0";
    }
    
    public static string LocatarioId(int id)
    {
        return $"SELECT * FROM Locatarios T0 WHERE T0.id = {id}";
    }    
    public static string NovoLocatario(LocatariosMigration model)
    {
        return @$"INSERT INTO Biopark.Locatarios
                  (nome, dataNasc, createdAt, updatedAt, isActive)
                VALUES('{model.nome}',
                       '{DateTime.Parse(model.dataNasc.ToString()).ToString("yyyy-MM-dd")}',
                       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
                       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
                       {true});";
    }

    public static string EditarLocatario(LocatariosMigration model, int id)
    {
        string nome = string.IsNullOrEmpty(model.nome) ? "" : $"nome='{model.nome}'";
        string dateNasc = string.IsNullOrEmpty(model.dataNasc.ToString()) ? "" : $"dataNasc='{DateTime.Parse(model.dataNasc.ToString()).ToString("yyyy-MM-dd")}'";
        string updatedAt = $"updatedAt='{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'";
        string isActive = $"isActive={model.isActive}";

        return $@"UPDATE Biopark.Locatarios
                    SET {nome}, {dateNasc}, {updatedAt}, {isActive}
                    WHERE id={id};";
    }

    public static string AtivarDesativarLocatario(bool isActive, int id)
    {
        return $@"UPDATE Biopark.Locatarios SET isActive={isActive} WHERE id={id}";
    }
}