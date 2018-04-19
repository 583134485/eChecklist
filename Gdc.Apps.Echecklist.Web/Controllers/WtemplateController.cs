using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gdc.Apps.Echecklist.Web.Controllers
{
    public class WtemplateController : ApiController
    {
        [HttpGet]
        [ActionName("listall")]
        public string GetAllTemplate()
        {
            return "all";
        }

        [HttpPost]
        [ActionName("getone")]
        public string GetoneTemplate([FromBody]string instance)
        {
            return " get one ";
        }

        [HttpPost]
        [ActionName("addone")]
        public string AddOneTemplate([FromBody]string instance)
        {
            return "add one";
        }

        [HttpPost]
        [ActionName("deletone")]
        public string DeletOneTemplate([FromBody]string instanceJson)
        {
            return "deletone";
        }

        [HttpPost]
        [ActionName("updateone")]
        public string UpdateOneTemplate([FromBody]string instanceJson)
        {
            return "update one";
        }
    }
}
