using Agl.Console.Model;
using System.Collections.Generic;

namespace Agl.Console.Service
{
    public interface IPetOwnerService
    {
        List<PetOwner> GetPetOwner();
        List<OrderedPet> OrderedListOfPet(string petType, List<PetOwner> owners);
    }
}
