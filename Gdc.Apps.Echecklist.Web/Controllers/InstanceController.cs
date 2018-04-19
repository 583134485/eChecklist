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
            //Instance instance = new Instance();
            //instance.Id = new MongoDB.Bson.ObjectId(instanceJson.Id);
            //instance.Name = instanceJson.Name;
            //instance.Template = instanceJson.Template;
            //instance.Type = instanceJson.Type;
            return this.instanceService.RemoveIntance(instance);
        }

        [HttpPost]
        [ActionName("updateinstance")]
        public InstanceView Updateinstance([FromBody]Instance instance)
        {
            //Instance instance = new Instance();
            //instance.Id = new MongoDB.Bson.ObjectId(instanceJson.Id);
            //instance.Name = instanceJson.Name;
            //instance.Template = instanceJson.Template;
            //instance.Type = instanceJson.Type;
            return this.instanceService.UpdateIntance(instance);
        }

        [HttpPost]
        [ActionName("addinstanceforstep")]
        public InstanceView DubugOne([FromBody]Instance instance)
        {
            return this.instanceService.InsertInstanceForStep(instance);
        }

        //[HttpPost]
        //[ActionName("debugone")]
        //public InstanceView DubugOne([FromBody]Instance instance)
        //{
        //    return this.instanceService.InsertBatchInsert(instance);
        //}
    }
}
