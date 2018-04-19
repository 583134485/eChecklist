using Gdc.Apps.Echecklist.Models.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gdc.Apps.Echecklist.Web.Controllers
{
    public class WinstanceController : ApiController
    {
        [HttpGet]
        [ActionName("listall")]
        public List<Winstance>  GetAllInstance()
        {
            return null;
        }

        [HttpPost]
        [ActionName("getone")]
        public Winstance GetoneInstance([FromBody]Winstance instance)
        {
            return null;
        }

        [HttpPost]
        [ActionName("addone")]
        public string AddOneInstance([FromBody]string instance)
        {
            return "add one";
        }

        [HttpPost]
        [ActionName("getdetails")]
        public string GetDeails([FromBody]string instance)
        {
            return "add one";
        }

        [HttpPost]
        [ActionName("deletone")]
        public string DeletOneInstance([FromBody]string instanceJson)
        {
            return "deletone";
        }

        [HttpPost]
        [ActionName("updateone")]
        public string UpdateOneInstance([FromBody]string instanceJson)
        {
            return "update one";
        }
    }
}
