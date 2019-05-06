using Agl.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agl.Services
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IWebClientService _webClient;
        public PetOwnerService(IWebClientService webClient)
        {
            _webClient = webClient;
        }
        public List<PetOwner> GetPetOwner()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };            

            var jsonResult = _webClient.GetPetOwnerJson();

            var owners = string.IsNullOrWhiteSpace(jsonResult)
                            ? new List<PetOwner>()
                            : JsonConvert.DeserializeObject<List<PetOwner>>(jsonResult, settings);

            return owners;
        }

        public List<GroupedPetOwner> GetGroupedAndSortedPetOwner(PetType petType, List<PetOwner> owners)
        {
            if (petType == PetType.Undefined)
                throw new ArgumentOutOfRangeException(nameof(petType));

            if (owners == null)
                return new List<GroupedPetOwner>();

            // Does not remove duplicate name as they are unique individuals
            var orderedPets = owners
                    .SelectMany(o => o.Pets.Where(p => p.Type == petType)
                        .Select(p => new { OwnerGender = o.Gender, PetName = p.Name }))
                    .OrderBy(x => x.OwnerGender)
                    .ThenBy(x => x.PetName);


            var groupedList = new List<GroupedPetOwner>();

            // Group elements by gender
            var genderGroped = orderedPets.GroupBy(a => a.OwnerGender.ToString());

            // Loop over groups.
            foreach (var group in genderGroped)
            {
                var petOwner = new GroupedPetOwner { OwnerGender = group.Key };
                foreach (var value in group)
                {
                    petOwner.Pets.Add(value.PetName);
                }
                groupedList.Add(petOwner);
            }


            return groupedList;
        }



    }
}
