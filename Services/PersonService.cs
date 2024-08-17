using BCrypt.Net;
using WebApiPerson.DTOs;
using WebApiPerson.Models;
using WebApiPerson.Repositories;

namespace WebApiPerson.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person CreatePerson(Person person)
        {
            // Asegúrate de encriptar la contraseña si no está vacía
            if (!string.IsNullOrEmpty(person.Password))
            {
                person.Password = BCrypt.Net.BCrypt.HashPassword(person.Password);
            }

            // Ahora, guarda la persona en el repositorio
            return _personRepository.Create(person);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public Person GetPersonById(int id)
        {
            return _personRepository.GetById(id);
        }

        public Person UpdateNameLastName(int id, UpdateNameLastNameDTO dto)
        {
            var person = _personRepository.GetById(id);
            if (person == null) return null;

            if (!string.IsNullOrEmpty(dto.Name)) person.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.LastName)) person.LastName = dto.LastName;

            _personRepository.Update(person);
            return person;
        }

        public Person UpdateUserName(int id, UpdateUserNameDTO dto)
        {
            var person = _personRepository.GetById(id);
            if (person == null) return null;

            if (!string.IsNullOrEmpty(dto.UserName)) person.UserName = dto.UserName;

            _personRepository.Update(person);
            return person;
        }

        public Person UpdatePassword(int id, UpdatePasswordDTO dto)
        {
            var person = _personRepository.GetById(id);
            if (person == null) return null;

            try
            {
                // Intentar verificar la contraseña actual
                if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, person.Password))
                {
                    return null; // Contraseña actual incorrecta
                }
            }
            catch (SaltParseException)
            {
                // El hash almacenado es inválido, lanzamos una excepción con un mensaje claro
                throw new Exception("El hash de la contraseña almacenado es inválido. Por favor, restablezca su contraseña.");
            }

            // Si se pasa la verificación, proceder a actualizar la contraseña
            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                person.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            }

            _personRepository.Update(person);
            return person;
        }
        public bool DeletePerson(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null) return false;

            _personRepository.Delete(person);
            return true;
        }
    }
}
