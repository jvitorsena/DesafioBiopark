using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Config.Queries;

public class ApartamentosQuery
{
    public static string TodosApartamentos()
    {
        return $@"SELECT
					T0.id,
					T0.numero,
					T0.andar,
					T0.alugado,
					T0.createdAt,
					T0.updatedAt,
					T0.isActive,
					T1.nome AS ""edificio"",
					T0.edificiosId
					    FROM
						    Apartamentos T0
						    INNER JOIN Edificios T1
						    WHERE
					    T0.edificiosId = T1.id";
    }

    public static string ApartamentoId(int id)
    {
        return $@"SELECT
					T0.id,
					T0.numero,
					T0.andar,
					T0.alugado,
					T0.createdAt,
					T0.updatedAt,
					T0.isActive,
					T1.nome AS ""edificio""
				        FROM
					        Apartamentos T0
					        INNER JOIN Edificios T1 ON
				        T0.edificiosId = T1.id
				        WHERE
				        T0.id = {id}";
    }

    public static string NovoApartamento(ApartamentosMigration model)
    {
        return $@"INSERT INTO Biopark.Apartamentos
					(numero, andar, alugado, createdAt, updatedAt, isActive, edificiosId)
					VALUES(
					{model.numero},
					 {model.andar},
					  {model.alugado},
					'{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
					       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
					       {true},
					       {model.edificiosId});";
    }

    public static string EditarApartamento(ApartamentosMigration model, int id)
    {
	    string numero = string.IsNullOrEmpty(model.numero.ToString()) ? "" : $"numero={model.numero}";
	    string andar = string.IsNullOrEmpty(model.andar.ToString()) ? "" : $@"andar={model.andar}";
	    string updatedAt = $"updatedAt='{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'";
	    string edificioId = string.IsNullOrEmpty(model.edificiosId.ToString()) ? "" : $"edificiosId={model.edificiosId}";
	    
	    return $@"UPDATE Biopark.Apartamentos
					SET
					{numero}, {andar}, {updatedAt}, {edificioId}
					WHERE id={id};";

    }

    public static string AtivarDesativarApartamento(bool isActive, int id)
    {
	    return $@"UPDATE Biopark.Apartamentos SET isActive={isActive} WHERE Id={id}";
    }
    
    public static string AlugarLiberarApartamento(bool alugado, int id)
    {
	    return $@"UPDATE Biopark.Apartamentos SET alugado={alugado} WHERE Id={id}";
    }
}