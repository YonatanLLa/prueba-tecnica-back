using WebApiPerson.DTOs;
using WebApiPerson.Models;

namespace WebApiPerson.Services
{
    public interface IPersonService
    {
        Person CreatePerson(Person person);
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        Person UpdateNameLastName(int id, UpdateNameLastNameDTO dto);
        Person UpdateUserName(int id, UpdateUserNameDTO dto);
        Person UpdatePassword(int id, UpdatePasswordDTO dto);
        bool DeletePerson(int id);
    }
}
