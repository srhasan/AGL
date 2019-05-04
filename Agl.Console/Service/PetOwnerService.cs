using Agl.Console.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Agl.Console.Service
{
    public class PetOwnerService: IPetOwnerService
    {
        private readonly IWebClientService _webClient;
        public PetOwnerService(IWebClientService webClient)
        {
            _webClient = webClient;
        }
        public List<PetOwner> GetPetOwner()
        {
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            var jsonResult = _webClient.GetPetOwnerJson();

            var owners = string.IsNullOrWhiteSpace(jsonResult) 
                            ? new List<PetOwner>()
                            : JsonConvert.DeserializeObject<List<PetOwner>>(jsonResult, settings);

            return owners;            
        }

        public List<OrderedPet> OrderedListOfPet(string petType, List<PetOwner> owners)
        {
            if (string.IsNullOrWhiteSpace(petType))
                throw new ArgumentNullException(nameof(petType));

            if (owners == null)
                return new List<OrderedPet>();

            // Does not remove duplicate name as they are unique individuals
            var orderedPets = owners
                    .SelectMany(o => o.Pets.Where(p => p.Type.ToLower() == petType.ToLower())
                        .Select(p => new OrderedPet { PetName = p.Name , OwnerGender = o.Gender }))
                    .OrderBy(x => x.OwnerGender)
                    .ThenBy(x => x.PetName);

            return orderedPets.ToList();            
        }



    }
}
