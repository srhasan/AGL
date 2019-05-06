using Agl.Model;
using Agl.Services;
using System.Collections.Generic;
using System.Configuration;

namespace Agl.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                As a simple demo no DI container is used here 
                but the code has been written in a way so that it will accept constructor injection 
                See Mvc.UI for an example of more realisting DI container
            */
            
            var client = new WebClientService(ConfigurationManager.AppSettings["jsonUrl"]);           
            var service = new PetOwnerService(client);

            var owners = service.GetPetOwner();
            var orderedPets = service.GetGroupedAndSortedPetOwner(PetType.Cat, owners);
            DisplayList(orderedPets);

            System.Console.ReadLine();
        }

        private static void DisplayList(List<GroupedPetOwner> groupedPets)
        {        
            foreach (var groupedOwner in groupedPets)
            {
                System.Console.WriteLine(groupedOwner.OwnerGender);
                System.Console.WriteLine("");
                foreach (var pet in groupedOwner.Pets)
                {
                    System.Console.WriteLine(pet);
                }
                System.Console.WriteLine("");
            }

        }
    }
}
