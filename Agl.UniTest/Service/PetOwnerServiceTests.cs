using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agl.Console.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.Console.Model;

namespace Agl.Console.Service.Tests
{
    [TestClass()]
    public class PetOwnerServiceTests
    {

        [TestMethod()]
        public void DisplayPetsGroupedByOwnerGender_NullList_Should_Pass()
        {
            var service = new PetOwnerService(null);
            var result = service.OrderedListOfPet(PetType.Cat, null);
            Assert.IsTrue(result != null);
        }

        [TestMethod()]
        public void DisplayPetsGroupedByOwnerGender_EmptyList_Should_Pass()
        {

            var service = new PetOwnerService(null);
            var result = service.OrderedListOfPet(PetType.Cat, new List<PetOwner>());
            Assert.IsTrue(result != null);
        }

        [TestMethod()]
        public void DisplayPetsGroupedByOwnerGender_ListShouldBeInOrder()
        {
            var service = new PetOwnerService(null);
            var unsortedOwner = new List<PetOwner> {
                new PetOwner { Age = 20, Gender = GenderType.Female, Name = "User1", Pets = new List<Pet> { new Pet {Name = "Scrappy", Type = PetType.Cat }, new Pet { Name = "Tom", Type = PetType.Cat } } },
                new PetOwner { Age = 20, Gender = GenderType.Male, Name = "User2", Pets = new List<Pet> { new Pet {Name = "Tom", Type = PetType.Cat }, new Pet { Name = "Alfie", Type = PetType.Cat } } },
                new PetOwner { Age = 22, Gender = GenderType.Female, Name = "User3", Pets = new List<Pet> { new Pet {Name = "Boa", Type = PetType.Cat }, new Pet { Name = "Polo", Type = PetType.Dog } } }
            };
            var result = service.OrderedListOfPet(PetType.Cat, unsortedOwner);
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result.First().PetName == "Alfie");
        }

        
    }
}