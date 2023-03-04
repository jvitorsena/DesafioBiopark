namespace DesafioBiopark.Model.Migrations;

public class LocatariosSeed
{
    public static readonly List<LocatariosMigration> Locatarios = new List<LocatariosMigration>
    {
        new LocatariosMigration
        {
            id = 1, dataNasc = new DateTime(1944, 01, 24), nome = "Alexandre Levi Renato Baptista",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new LocatariosMigration
        {
            id = 2, dataNasc = new DateTime(1944, 01, 24), nome = "Alexandre Levi Renato Baptista",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new LocatariosMigration
        {
            id = 3, dataNasc = new DateTime(2002, 02, 03), nome = "Liz Sônia Bernardes",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },       
        new LocatariosMigration
        {
            id = 4, dataNasc = new DateTime(1952, 02, 08), nome = "Lucas Pietro Noah Moura",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new LocatariosMigration
        {
            id = 5, dataNasc = new DateTime(1962, 02, 11), nome = "Elaine Natália Renata Souza",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new LocatariosMigration
        {
            id = 6, dataNasc = new DateTime(1945, 02, 16), nome = "Elisa Bianca Porto",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },      
        new LocatariosMigration
        {
            id = 7, dataNasc = new DateTime(1978, 02, 03), nome = "Francisca Isabelly Débora Rocha",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },     
        new LocatariosMigration
        {
            id = 8, dataNasc = new DateTime(1989, 03, 01), nome = "Alexandre Bryan Nogueira",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },   
        new LocatariosMigration
        {
            id = 9, dataNasc = new DateTime(1982, 01, 10), nome = "Nicole Analu Sarah Brito",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },   
        new LocatariosMigration
        {
            id = 10, dataNasc = new DateTime(1954, 03, 01), nome = "Daiane Sabrina da Rosa",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },       
        new LocatariosMigration
        {
            id = 11, dataNasc = new DateTime(1978, 02, 12), nome = "Benício Manuel Lima",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
    };
}