using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Agl.Console.Model
{
    public class PetOwner
    {
        public PetOwner()
        {
            Pets = new List<Pet>();
        }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "gender")]
        [JsonConverter(typeof(StringEnumConverter))] 
        // Custom enum converter was not used for test purpose. This requires 1 to 1 mapping and fail to deserialize if there is a mismatch
        public GenderType Gender { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "pets")]
        public List<Pet> Pets { get; set; }
    }

    public class Pet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        // Custom enum converter was not used for test purpose. This requires 1 to 1 mapping and fail to deserialize if there is a mismatch
        public PetType Type { get; set; }

    }
}
