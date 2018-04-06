using PersonRepository.Interface;
using System;
using System.Configuration;

namespace PeopleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository()
        {
            //get info from config about which repo to instantiate
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];

            //get actual type, then create instance
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);

            return repoInstance as IPersonRepository;
        }
    }
}
