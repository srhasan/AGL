using Agl.Model;
using Agl.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Agl.Console.Service.Tests
{
    [TestClass()]
    public class PetOwnerServiceTests
    {
        private string mockedResponse = "[{'name':'Bob','gender':'Male','age':23,'pets':[{'name':'Garfield','type':'Cat'},{'name':'Fido','type':'Dog'}]},{'name':'Jennifer','gender':'Female','age':18,'pets':[{'name':'Garfield','type':'Cat'}]},{'name':'Steve','gender':'Male','age':45,'pets':null},{'name':'Fred','gender':'Male','age':40,'pets':[{'name':'Tom','type':'Cat'},{'name':'Max','type':'Cat'},{'name':'Sam','type':'Dog'},{'name':'Jim','type':'Cat'}]},{'name':'Samantha','gender':'Female','age':40,'pets':[{'name':'Tabby','type':'Cat'}]},{'name':'Alice','gender':'Female','age':64,'pets':[{'name':'Simba','type':'Cat'},{'name':'Nemo','type':'Fish'}]}]";

        [TestMethod()]
        public void GetPetOwner_ValidClientResponse_Should_Return_Correct_Number_Of_Result()
        {
            // Arrange
            var mockedClientService = new Mock<IWebClientService>();
            mockedClientService.Setup(x => x.GetPetOwnerJson()).Returns(mockedResponse);
            var service = new PetOwnerService(mockedClientService.Object);

            //Act
            var result = service.GetPetOwner();
            
            //Assert
            Assert.IsTrue(result.Count == 6);
        }

        [TestMethod()]
        public void GetGroupedAndSortedPetOwner_ListShouldBeInOrder()
        {
            // Arrange
            var mockedClientService = new Mock<IWebClientService>();
            mockedClientService.Setup(x => x.GetPetOwnerJson()).Returns(mockedResponse);
            var service = new PetOwnerService(mockedClientService.Object);

            //ACT
            var unsortedOwner = service.GetPetOwner();
            var result = service.GetGroupedAndSortedPetOwner(PetType.Cat, unsortedOwner);

            // Assert
            Assert.IsTrue(result.First().Pets.First() == "Garfield", "Pet names should be sorted");
        }

        [TestMethod()]
        public void GetGroupedAndSortedPetOwner_NullList_Should_Pass()
        {
            var service = new PetOwnerService(null);
            var result = service.GetGroupedAndSortedPetOwner(PetType.Cat, null);
            Assert.IsTrue(result != null);
        }

        [TestMethod()]
        public void GetGroupedAndSortedPetOwner_EmptyList_Should_Pass()
        {
            var service = new PetOwnerService(null);
            var result = service.GetGroupedAndSortedPetOwner(PetType.Cat, new List<PetOwner>());
            Assert.IsTrue(result != null);
        }

        

        
    }
}