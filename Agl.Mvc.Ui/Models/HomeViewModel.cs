using Agl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Mvc.Ui.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(List<GroupedPetOwner> orderedPets )
        {
            PetOwners = new List<PetOwner>();

            foreach (var genderGroup in orderedPets)
            {
                var petOwner = new PetOwner {OwnerGender = genderGroup.OwnerGender};
                foreach (var pet in genderGroup.Pets)
                {
                    petOwner.Pets.Add(pet);
                }
                PetOwners.Add(petOwner);
            }            
        }

        public List<PetOwner> PetOwners { get; set; }        
    }

    public class PetOwner
    {
        public PetOwner()
        {
            Pets = new List<string>();
        }
        public string OwnerGender { get; set; }

        public List<string> Pets { get; set; }        
    }
}
