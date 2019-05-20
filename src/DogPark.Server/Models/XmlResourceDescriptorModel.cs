using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DogPark.Server.Models
{

    [XmlRoot("XRD", Namespace = "http://docs.oasis-open.org/ns/xri/xrd-1.0")]
    public class XmlResourceDescriptorModel
    {
        public XmlResourceDescriptorExpiresModel? Expires { get; set; }

        public string? Subject { get; set; }

        [XmlElement("Alias")]
        public string[]? Aliases { get; set; }

        [XmlElement("Property")]
        public XmlResourceDescriptorPropertyModel[]? Properties { get; set; }

        [XmlElement("Link")]
        public XmlResourceDescriptorLinkRelationModel[]? Links { get; set; }
    }

    public class XmlResourceDescriptorExpiresModel
    {
        [XmlIgnore]
        public DateTimeOffset? Value { get; set; }

        [XmlText]
        public string? Text => Value?.ToString("O");
    }

    public class XmlResourceDescriptorLinkRelationModel
    {
        [XmlAttribute("rel")]
        public string? Rel { get; set; }

        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlAttribute("href")]
        public string? Href { get; set; }

        [XmlAttribute("template")]
        public string? Template { get; set; }

        [XmlElement("Title")]
        public XmlResourceDescriptorTitleModel[]? Titles { get; set; }

        [XmlElement("Property")]
        public XmlResourceDescriptorPropertyModel[]? Properties { get; set; }
    }

    public class XmlResourceDescriptorTitleModel
    {
        [XmlAttribute("lang")]
        public string? Lang { get; set; }

        [XmlText]
        public string? Value { get; set; }
    }

    public class XmlResourceDescriptorPropertyModel
    {
        [XmlAttribute("type")]
        public string? Type { get; set; }

        [XmlText]
        public string? Value { get; set; }
    }
}
