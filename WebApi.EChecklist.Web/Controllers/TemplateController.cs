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
    public class TemplateController : ApiController
    {
        private ITemplateService templateService;

        // TemplateController()
        // {
        //    templateService = new TemplateServiceImp();
        // }
        // construction for injector
        public TemplateController(ITemplateService templateService)
        {
            this.templateService = templateService;
        }

        [HttpGet]
        [ActionName("listall")]
        public TemplateView GetAll()
        {
            return this.templateService.GetAllTemplate();
        }

        [HttpPost]
        [ActionName("getone")]
        public TemplateView Getone([FromBody]Template template)
        {
            return this.templateService.GetOneTemplate(template);
        }

        [HttpPost]
        [ActionName("addone")]
        public TemplateView AddOne([FromBody]Template template)
        {
            return this.templateService.InsertTemplate(template);
        }

        [HttpPost]
        [ActionName("delettemplate")]
        public TemplateView Delettemplate([FromBody]Template template)
        {
            return this.templateService.RemoveTemplate(template);
        }

        [HttpPost]
        [ActionName("updatetemplate")]
        public TemplateView Updatetemplate([FromBody]Template template)
        {
            return this.templateService.UpdateTemplate(template);
        }
    }
}
