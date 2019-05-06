using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Agl.Model
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
}
