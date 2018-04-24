using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gdc.Apps.Echecklist.Web.Test.Controllers
{
    /// <summary>
    /// 测试API Test Client
    /// </summary>
    public class ApiTestWorkflowController : ApiController
    {
        private IWorkflowService workflowService;


        // simpleinjector for webapi
        public ApiTestWorkflowController(IWorkflowService workflowService)
        {
            this.workflowService = workflowService;
        }

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns>返回数据</returns>
        [HttpGet]
        [ActionName("listall")]
        public ViewData<Workflow> GetAllWorkflow()
        {
            return workflowService.GetAll();
        }
    }
}
