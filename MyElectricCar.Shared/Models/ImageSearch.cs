using Newtonsoft.Json;

namespace MyElectricCar.Shared.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageSearch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
