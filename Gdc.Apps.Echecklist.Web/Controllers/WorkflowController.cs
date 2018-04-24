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
    public class WorkflowController : ApiController
    {

        private readonly IWorkflowService workflowService;


        // simpleinjector for webapi
        public WorkflowController(IWorkflowService workflowService)
        {
            this.workflowService = workflowService;
        }


        [HttpGet]
        [ActionName("listall")]
        public ViewData<Workflow> GetAllWorkflow()
        {
            return workflowService.GetAllWorkflow();
        }

        [HttpPost]
        [ActionName("getone")]
        public ViewData<Workflow> Getone([FromBody]Workflow workflow)
        {
            return workflowService.GetOneWorkflow(workflow);
        }

        //turn to  details page for more information pr to net step
        [HttpPost]
        [ActionName("getdetails")]
        public ViewData<Step> GetDetails([FromBody]Workflow workflow)
        {
            return workflowService.GetStepsByWorkflowId(workflow);
        }

        [HttpPost]
        [ActionName("addone")]
        public ViewData<Workflow> AddOneWorkflow([FromBody]Workflow workflow)
        {
            return workflowService.InsertWorkflow(workflow);
        }

        [HttpPost]
        [ActionName("deletone")]
        public ViewData<Workflow> DeletOneWorkflow([FromBody]Workflow workflow)
        {
            return workflowService.RemoveWorkflow(workflow);
        }


        //just update a little not for 
        [HttpPost]
        [ActionName("updateone")]
        public ViewData<Workflow> UpdateOneWorkflow([FromBody]Workflow workflow)
        {
            return workflowService.UpdateWorkflow(workflow);
        }


    }
}
