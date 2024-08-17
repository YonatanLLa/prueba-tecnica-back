using Microsoft.AspNetCore.Mvc;
using WebApiPerson.DTOs;

namespace WebApiPerson.Controllers
{
    public IActionResult UpdatePassword(int id, [FromBody] UpdatePasswordDTO dto)
    {
        try
        {
            var updatedPerson = _personService.UpdatePassword(id, dto);
            if (updatedPerson == null)
            {
                return NotFound(new { message = "Contraseña actual incorrecta o usuario no encontrado." });
            }
            return Ok(updatedPerson);
        }
        catch (Exception ex)
        {
            // Registrar el error
            Console.WriteLine(ex.Message);

            // Responder al usuario con una sugerencia de cambio de contraseña
            return BadRequest(new { message = "Hubo un problema con su contraseña actual. Por favor, restablezca su contraseña." });
        }
    }

}
