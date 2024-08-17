using System.ComponentModel.DataAnnotations;
using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;

namespace WebApiPerson.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }  // Cambiado a PasswordHash
        public string PhoneNumber { get; set; }

        // Método para hash de la contraseña
      
    }
}
