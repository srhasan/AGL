using Agl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Services
{
    public interface IPetOwnerService
    {
        List<PetOwner> GetPetOwner();
        List<GroupedPetOwner> GetGroupedAndSortedPetOwner(PetType petType, List<PetOwner> owners);
    }
}
