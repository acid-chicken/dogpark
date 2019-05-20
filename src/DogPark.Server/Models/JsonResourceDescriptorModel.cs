using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DogPark.Server.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class JsonResourceDescriptorModel
    {
        public DateTimeOffset? Expires { get; set; }

        public string? Subject { get; set; }

        public IEnumerable<string>? Aliases { get; set; }

        public IDictionary<string, string>? Properties { get; set; }

        public IEnumerable<JsonResourceDescriptorLinkRelationModel>? Links { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class JsonResourceDescriptorLinkRelationModel
    {
        public string? Rel { get; set; }

        public string? Type { get; set; }

        public string? Href { get; set; }

        public string? Template { get; set; }

        public IDictionary<string, string>? Titles { get; set; }
        
        public IDictionary<string, string>? Properties { get; set; }
    }
}
