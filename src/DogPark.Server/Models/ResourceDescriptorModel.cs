using System;
using System.Collections.Generic;
using System.Linq;

namespace DogPark.Server.Models
{
    public class ResourceDescriptorModel
    {
        public ResourceDescriptorModel(DateTimeOffset? expires = default, string? subject = default, IEnumerable<string>? aliases = default, IDictionary<string, string>? properties = default, params ResourceDescriptorLinkRelationModel[]? links)
        {
            Expires = expires;
            Subject = subject;
            Aliases = aliases?.ToArray();
            Properties = properties?.ToDictionary(x => x.Key, x => x.Value);
            Links = links?.ToArray();
        }

        public DateTimeOffset? Expires { get; set; }

        public string? Subject { get; set; }

        public IEnumerable<string>? Aliases { get; set; }

        public IDictionary<string, string>? Properties { get; set; }

        public IEnumerable<ResourceDescriptorLinkRelationModel>? Links { get; set; }

        public JsonResourceDescriptorModel ToJsonResourceDescriptor()
        {
            return (JsonResourceDescriptorModel)this;
        }

        public XmlResourceDescriptorModel ToXmlResourceDescriptor()
        {
            return (XmlResourceDescriptorModel)this;
        }

        public static explicit operator JsonResourceDescriptorModel(ResourceDescriptorModel model)
        {
            return new JsonResourceDescriptorModel()
            {
                Expires = model.Expires,
                Subject = model.Subject,
                Aliases = model.Aliases?.ToArray(),
                Properties = model.Properties?.ToDictionary(x => x.Key, x => x.Value),
                Links = model.Links?.Select(x => new JsonResourceDescriptorLinkRelationModel()
                {
                    Rel = x.Rel,
                    Type = x.Type,
                    Href = x.Href,
                    Template = x.Template,
                    Titles = x.Titles,
                    Properties = x.Properties
                }).ToArray()
            };
        }

        public static explicit operator XmlResourceDescriptorModel(ResourceDescriptorModel model)
        {
            return new XmlResourceDescriptorModel()
            {
                Expires = model.Expires is null ? default : new XmlResourceDescriptorExpiresModel()
                {
                    Value = model.Expires.Value
                },
                Subject = model.Subject,
                Aliases = model.Aliases?.ToArray(),
                Properties = model.Properties?.Select(x => new XmlResourceDescriptorPropertyModel()
                {
                    Type = x.Key,
                    Value = x.Value
                }).ToArray(),
                Links = model.Links?.Select(x => new XmlResourceDescriptorLinkRelationModel()
                {
                    Rel = x.Rel,
                    Type = x.Type,
                    Href = x.Href,
                    Template = x.Template,
                    Titles = x.Titles?.Select(x => new XmlResourceDescriptorTitleModel()
                    {
                        Lang = x.Key,
                        Value = x.Value
                    }).ToArray(),
                    Properties = x.Properties?.Select(x => new XmlResourceDescriptorPropertyModel()
                    {
                        Type = x.Key,
                        Value = x.Value
                    }).ToArray()
                }).ToArray()
            };
        }
    }

    public class ResourceDescriptorLinkRelationModel
    {
        public ResourceDescriptorLinkRelationModel(string rel, string? type = default, string? href = default, string? template = default, IDictionary<string, string>? titles = default, IDictionary<string, string>? properties = default)
        {
            Rel = rel;
            Type = type;
            Href = href;
            Template = template;
            Titles = titles;
            Properties = properties;
        }

        public string Rel { get; set; }

        public string? Type { get; set; }

        public string? Href { get; set; }

        public string? Template { get; set; }

        public IDictionary<string, string>? Titles { get; set; }
        
        public IDictionary<string, string>? Properties { get; set; }
    }
}
