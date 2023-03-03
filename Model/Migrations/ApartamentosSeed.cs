using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Model.Migrations;

public class ApartamentosSeed
{
    public static readonly List<ApartamentosMigration> Apartamentos = new List<ApartamentosMigration>
    {
        new ApartamentosMigration
        {
            id = 1, numero = 101, andar = 1, alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new ApartamentosMigration
        {
            id = 2, numero = 102, andar = 1, alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },       
        new ApartamentosMigration
        {
            id = 3, numero = 201, andar = 2, alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },    
        new ApartamentosMigration
        {
            id = 4, numero = 202, andar = 2,  alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },     
        new ApartamentosMigration
        {
            id = 5, numero = 301, andar = 3,  alugado = true, edificiosId = 1, 
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new ApartamentosMigration
        {
            id = 6, numero = 302, andar = 3,  alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new ApartamentosMigration
        {
            id = 7, numero = 401, andar = 4,  alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new ApartamentosMigration
        {
            id = 8, numero = 402, andar = 4,  alugado = true, edificiosId = 1,
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
    };
}