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
                  (primeiroNome, segundoNome, dataNasc, createdAt, updatedAt, isActive)
                VALUES('{model.primeiroNome}',
                       '{model.segundoNome}',
                       '{DateTime.Parse(model.dataNasc.ToString()).ToString("yyyy-MM-dd")}',
                       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
                       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
                       {true});";
    }

    public static string EditarLocatario(LocatariosMigration model, int id)
    {
        string primeiroNome = string.IsNullOrEmpty(model.primeiroNome) ? "" : $"primeiroNome='{model.primeiroNome}'";
        string segundoNome = string.IsNullOrEmpty(model.segundoNome) ? "" : $"segundoNome='{model.segundoNome}'";
        string dateNasc = string.IsNullOrEmpty(model.dataNasc.ToString()) ? "" : $"dataNasc='{DateTime.Parse(model.dataNasc.ToString()).ToString("yyyy-MM-dd")}'";
        string updatedAt = $"updatedAt='{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'";
        string isActive = $"isActive{model.isActive}";

        return $@"UPDATE Biopark.Locatarios
                    SET {primeiroNome}, {segundoNome}, {dateNasc}, {updatedAt}, {isActive}
                    WHERE id={id};";
    }

    public static string AtivarDesativarLocatario(bool isActive, int id)
    {
        return $@"UPDATE Biopark.Edificios SET isActive={isActive} WHERE id={id}";
    }
}