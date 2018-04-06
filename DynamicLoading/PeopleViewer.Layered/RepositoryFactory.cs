using PersonRepository.Interface;
using System;
using System.Configuration;

namespace PeopleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            IPersonRepository repo = repoInstance as IPersonRepository;
            return repo;
        }
    }
}
