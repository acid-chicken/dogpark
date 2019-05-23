using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogPark.Server.Models;
using DogPark.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DogPark.Server.Controllers
{
    [Route(WellKnownUriRegistryTypes.WellKnown)]
    [ApiController]
    public class WellKnownController : ControllerBase
    {
        public WellKnownController(DogParkContext context)
        {
            Context = context;
        }

        public DogParkContext Context { get; }

        [HttpGet(WellKnownUriRegistryTypes.WebHostMetadata)]
        [Produces(ContentTypes.XmlResourceDescriptor)]
        public ActionResult<XmlResourceDescriptorModel> HostMeta()
        {
            return new HostMetaModel(Url).ToXmlResourceDescriptor();
        }

        [HttpGet(WellKnownUriRegistryTypes.WebHostMetadataJson)]
        [Produces(ContentTypes.JsonResourceDescriptor)]
        public ActionResult<JsonResourceDescriptorModel> HostMetaJson()
        {
            return new HostMetaModel(Url).ToJsonResourceDescriptor();
        }

        [HttpGet(WellKnownUriRegistryTypes.WebFinger)]
        [Produces(ContentTypes.XmlResourceDescriptor, ContentTypes.JsonResourceDescriptor)]
        public IActionResult WebFinger([FromQuery] string resource)
        {
            return StatusCode(503); // ToDo
        }
    }
}
