using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Config.Queries;

public class ContratosQuery
{
        public static string TodosContratos()
        {
                return $@"SELECT
	                        T0.id,
	                        T0.valorAluguelMen,
	                        T0.locatarioId,
	                        T0.apartamentoId,
	                        CONCAT(T1.nome) AS ""locatario"",
                                        T2.numero AS ""apartamento"",
                                        T0.createdAt,
                                        T0.updatedAt,
                                        T0.isActive
                                                FROM
                                        Contratos T0
                                        INNER JOIN Locatarios T1 ON
                                        T0.locatarioId = T1.id
                                        INNER JOIN Apartamentos T2 ON
                                        T0.apartamentoId = T2.id";
        }
        public static string ContratoId(int id)
        {
            return $@"SELECT
	                        T0.id,
	                        T0.valorAluguelMen,
	                        CONCAT(T1.nome) AS ""locatario"",
                                        T2.numero AS ""apartamento"",
                                        T0.createdAt,
                                        T0.updatedAt,
                                        T0.isActive
                                                FROM
                                        Contratos T0
                                        INNER JOIN Locatarios T1 ON
                                        T0.locatarioId = T1.id
                                        INNER JOIN Apartamentos T2 ON
                                        T0.apartamentoId = T2.id
							WHERE T0.id={id}";
        }

        public static string NovoContrato(ContratoMigration model)
        {
	        return $@"INSERT INTO Biopark.Contratos
					(valorAluguelMen, createdAt, updatedAt, isActive, locatarioId, apartamentoId)
					VALUES({model.valorAluguelMen},
					       '{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
							'{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}',
					       {true},
					       {model.locatarioId},
					       {model.apartamentoId});
					";
        }

        public static string EditarContrato(ContratoMigration model, int id)
        {
	        string valorAluguelMen = string.IsNullOrEmpty(model.valorAluguelMen.ToString()) ? "" : $"valorAluguelMen={model.valorAluguelMen}";
	        string updatedAt = $"updatedAt='{DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'";
	        string locatarioId = string.IsNullOrEmpty(model.locatarioId.ToString()) ? "" : $"locatarioId={model.locatarioId}";
	        string apartamentoId = string.IsNullOrEmpty(model.apartamentoId.ToString()) ? "" : $"apartamentoId={model.apartamentoId}";
	        
	        return $@"UPDATE Biopark.Contratos
						SET {valorAluguelMen},
						    {updatedAt}, 
						    {locatarioId},
						    {apartamentoId}
						WHERE id={id};";
        }

        public static string AtivarDesativarContrato(bool isActive, int id)
        {
	        return $"UPDATE Biopark.Contratos SET isActive={isActive} WHERE id={id}";
        }
}