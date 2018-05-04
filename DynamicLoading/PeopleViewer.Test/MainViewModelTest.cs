using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleViewer.Test
{
    [TestClass]
    public class MainViewModelTest
    {

        [TestMethod]
        public void People_OnFetchData_IsPopulated()
        {
            //arrange
            var vm = new MainViewModel();

            //act
            vm.FetchData();

            //assert
            Assert.IsNotNull(vm.People);
            Assert.AreEqual(2, vm.People.Count());
        }

        [TestMethod]
        public void RepositoryType_OnCreation_ReturnsFakeRepositoryString()
        {
            var vm = new MainViewModel();
            var expectedString = "PersonRepository.Fake.FakeRepository";

            Assert.AreEqual(expectedString, vm.RepositoryType);
        }
    }
}
