using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public string Gender { get; set; }

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
        public string Type { get; set; }

    }
}
