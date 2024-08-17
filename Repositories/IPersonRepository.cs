using WebApiPerson.Models;

namespace WebApiPerson.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Update(Person person);
        void Delete(Person person);
    }
}
