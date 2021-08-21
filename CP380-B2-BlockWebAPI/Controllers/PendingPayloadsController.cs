using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        // TODO
        private readonly PendingPayloadsList pp;
        public PendingPayloadsController(PendingPayloadsList payloads)
        {
            pp = payloads;
        }

        [HttpGet]
        public ActionResult<List<Payload>> Get()
        {
            var item = pp.payloads;
            var pay = item.ToList();
            return (pay);
        }
        [HttpPost]
        public ActionResult<Payload> Post(Payload data)
        {
            pp.payloads.Add(data);
            return data;
        }
    }
}
