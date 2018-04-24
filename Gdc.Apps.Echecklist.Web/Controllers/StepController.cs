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
    public class StepController : ApiController
    {
        private  readonly IStepService stepService;
        public StepController(IStepService stepService)
        {
            this.stepService = stepService;
        }
        [HttpGet]
        [ActionName("listall")]
        public StepView GetAllStep()
        {
            return stepService.GetAllSteps();
        }
       


        [HttpPost]
        [ActionName("getdetails")]
        public ViewData<Instance> GetoneDetails([FromBody]Step step)
        { 
            return stepService.GetInstanceByStep(step);
        }

        [HttpPost]
        [ActionName("addone")]
        public StepView AddOneStep([FromBody]Step step)
        {
            return stepService.AddStep(step);
        }

        [HttpPost]
        [ActionName("deletone")]
        public StepView DeletOneStep([FromBody]Step step)
        {
            return stepService.RemoveStep(step);
        }

        [HttpPost]
        [ActionName("updateone")]
        public StepView UpdateOneStep([FromBody]Step step)
        {
            return stepService.EditStep(step);
        }
    }
}
