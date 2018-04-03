using PersonRepository.Interface;
using PersonRepository.Service.MyService;
using System.Collections.Generic;
using System.Linq;

namespace PersonRepository.Service
{
    public class ServiceRepository : IPersonRepository
    {

        PersonServiceClient serviceProxy = new PersonServiceClient();

        public void AddPerson(Person newPerson)
        {
            serviceProxy.AddPerson(newPerson);
        }

        public void DeletePerson(string lastName)
        {
            serviceProxy.DeletePerson(lastName);
        }

        public IEnumerable<Person> GetPeople()
        {
            return serviceProxy.GetPeople();
        }

        public Person GetPerson(string lastName)
        {
            return serviceProxy.GetPerson(lastName);
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            serviceProxy.UpdatePeople(updatedPeople.ToList());
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            serviceProxy.UpdatePerson(lastName, updatedPerson);
        }
    }
}
