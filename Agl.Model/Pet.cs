using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Agl.Model
{
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
