using System;
using System.Collections.Generic;
using System.Web;
using DogPark.Server.Controllers;
using DogPark.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DogPark.Server.Models
{
    public class HostMetaModel : ResourceDescriptorModel
    {
        public HostMetaModel(IUrlHelper url) :
            base(default, default, default, default, new ResourceDescriptorLinkRelationModel(RelationTypes.LinkBasedResourceDescriptorDocument, ContentTypes.XmlResourceDescriptor, HttpUtility.UrlDecode(url.Action(nameof(WellKnownController.WebFinger), default, new
            {
                resource = "{}"
            }, ProtocolTypes.Https))), new ResourceDescriptorLinkRelationModel(RelationTypes.LinkBasedResourceDescriptorDocument, ContentTypes.JsonResourceDescriptor, HttpUtility.UrlDecode(url.Action(nameof(WellKnownController.WebFinger), default, new
            {
                resource = "{}"
            }, ProtocolTypes.Https))))
        {
        }
    }
}
