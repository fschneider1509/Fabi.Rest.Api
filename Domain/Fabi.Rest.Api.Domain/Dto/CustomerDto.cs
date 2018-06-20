using Newtonsoft.Json;

namespace Fabi.Rest.Api.Domain.Dto
{
    public class CustomerDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("contactPerson")]
        public string ContactPerson { get; set; }
    }
}