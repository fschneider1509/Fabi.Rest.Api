using Newtonsoft.Json;

namespace Fabi.Rest.Api.Domain.Dto
{
    public class AppDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("version")]
        public string Version { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("isBeta")]
        public bool IsBeta { get; set; }

        [JsonProperty("appType")]
        public AppTypeDto AppType { get; set;}
    }
}