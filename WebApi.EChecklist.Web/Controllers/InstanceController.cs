using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.EChecklist.Models.MongoModels;
using WebApi.EChecklist.Models.ViewModels;
using WebApi.EChecklist.Providers.Interface;

namespace WebApi.EChecklist.Web.Controllers
{
    public class InstanceController : ApiController
    {
        private IInstanceService instanceService;

        // construction for   interface by new
        // InstanceController()
        // {
        //    instanceService = new InstanceServiceImp();
        // }
        // simpleinjector for webapi
        public InstanceController(IInstanceService instanceService)
        {
            this.instanceService = instanceService;
        }

        [HttpGet]
        [ActionName("listall")]
        public InstanceView GetAllInstance()
        {
            return this.instanceService.GetAllInstance();
        }

        [HttpPost]
        [ActionName("getone")]
        public InstanceView Getone([FromBody]Instance instance)
        {
            return this.instanceService.GetOneInstance(instance);
        }

        [HttpPost]
        [ActionName("addone")]
        public InstanceView AddOneInstance([FromBody]Instance instance)
        {
            return this.instanceService.InsertInstance(instance);
        }

        [HttpPost]
        [ActionName("deletinstance")]
        public InstanceView Deletinstance([FromBody]Instance instance)
        {
            return this.instanceService.RemoveIntance(instance);
        }

        [HttpPost]
        [ActionName("updateinstance")]
        public InstanceView Updateinstance([FromBody]Instance instance)
        {
            return this.instanceService.UpdateIntance(instance);
        }
    }
}
