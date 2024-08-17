using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;
using WebApiPerson.Models;

namespace WebApiPerson.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _context.Persons.Find(id);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
