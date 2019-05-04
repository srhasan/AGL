using Agl.Console.Model;
using Agl.Console.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // As a simple demo no DI container is used here 
            // but the code has been written in a way so that it will accept constructor injection 
            var client = new WebClientService();           
            var service = new PetOwnerService(client);

            var owners = service.GetPetOwner();
            var orderedPets = service.OrderedListOfPet("Cat", owners);
            DisplayList(orderedPets);

            System.Console.ReadLine();
        }

        private static void DisplayList(List<OrderedPet> orderedPets)
        {
            var lastGender = string.Empty;

            foreach (var pet in orderedPets)
            {
                if (lastGender != pet.OwnerGender)
                {
                    lastGender = pet.OwnerGender;
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"{lastGender} owner");
                    System.Console.WriteLine("");
                }
                System.Console.WriteLine(pet.PetName);
            }
        }
    }
}
