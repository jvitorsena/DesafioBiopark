using DesafioBiopark.Model.Migrations;

namespace DesafioBiopark.Model.Migrations;

public class LocatariosSeed
{
    public static readonly List<LocatariosMigration> Locatarios = new List<LocatariosMigration>
    {
        new LocatariosMigration
        {
            id = 1, dataNasc = new DateTime(1944, 01, 24), primeiroNome = "Alexandre Levi", segundoNome = "Renato Baptista",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new LocatariosMigration
        {
            id = 2, dataNasc = new DateTime(1944, 01, 24), primeiroNome = "Alexandre Levi", segundoNome = "Renato Baptista",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new LocatariosMigration
        {
            id = 3, dataNasc = new DateTime(2002, 02, 03), primeiroNome = "Liz", segundoNome = "Sônia Bernardes",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },       
        new LocatariosMigration
        {
            id = 4, dataNasc = new DateTime(1952, 02, 08), primeiroNome = "Lucas", segundoNome = "Pietro Noah Moura",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
        new LocatariosMigration
        {
            id = 5, dataNasc = new DateTime(1962, 02, 11), primeiroNome = "Elaine", segundoNome = "Natália Renata Souza",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        }, 
        new LocatariosMigration
        {
            id = 6, dataNasc = new DateTime(1945, 02, 16), primeiroNome = "Elisa", segundoNome = "Bianca Porto",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },      
        new LocatariosMigration
        {
            id = 7, dataNasc = new DateTime(1978, 02, 03), primeiroNome = "Francisca", segundoNome = "Isabelly Débora Rocha",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },     
        new LocatariosMigration
        {
            id = 8, dataNasc = new DateTime(1989, 03, 01), primeiroNome = "Alexandre", segundoNome = "Bryan Nogueira",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },   
        new LocatariosMigration
        {
            id = 9, dataNasc = new DateTime(1982, 01, 10), primeiroNome = "Nicole", segundoNome = "Analu Sarah Brito",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },   
        new LocatariosMigration
        {
            id = 10, dataNasc = new DateTime(1954, 03, 01), primeiroNome = "Daiane", segundoNome = "Sabrina da Rosa",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },       
        new LocatariosMigration
        {
            id = 11, dataNasc = new DateTime(1978, 02, 12), primeiroNome = "Benício", segundoNome = "Manuel Lima",
            createdAt = DateTime.Now, updatedAt = DateTime.Now, isActive = true
        },
    };
}