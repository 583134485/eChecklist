using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
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

        private readonly IWtemplateService wtemplateService;


        // simpleinjector for webapi
        public WtemplateController(IWtemplateService wtemplateService)
        {
            this.wtemplateService = wtemplateService;
        }
        [HttpGet]
        [ActionName("listall")]
        public string GetAllTemplate()
        {
            return "all list";
        }

        [HttpGet]
        [ActionName("getdefaultone")]
        public ViewData<Wtemplate> GetDefaultOne([FromBody]string instance)
        {
            return wtemplateService.GetDefaultWtemplate();
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
