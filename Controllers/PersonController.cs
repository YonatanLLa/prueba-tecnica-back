using Microsoft.AspNetCore.Mvc;
using WebApiPerson.DTOs;
using WebApiPerson.Models;
using WebApiPerson.Services;

namespace WebApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // Crear un nuevo usuario
        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            var createdPerson = _personService.CreatePerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
        }

        // Obtener todos los usuarios
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.GetAllPersons();
            return Ok(persons);
        }

        // Obtener un usuario por ID
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // Actualizar nombre y apellido del usuario
        [HttpPut("{id}/update-name-lastname")]
        public IActionResult UpdateNameLastName(int id, [FromBody] UpdateNameLastNameDTO dto)
        {
            var updatedPerson = _personService.UpdateNameLastName(id, dto);
            if (updatedPerson == null)
            {
                return NotFound();
            }
            return Ok(updatedPerson);
        }

        // Actualizar nombre de usuario
        [HttpPut("{id}/update-username")]
        public IActionResult UpdateUserName(int id, [FromBody] UpdateUserNameDTO dto)
        {
            var updatedPerson = _personService.UpdateUserName(id, dto);
            if (updatedPerson == null)
            {
                return NotFound();
            }
            return Ok(updatedPerson);
        }

        // Actualizar contraseña
        [HttpPut("{id}/update-password")]
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


        // Eliminar un usuario por ID
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var result = _personService.DeletePerson(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
