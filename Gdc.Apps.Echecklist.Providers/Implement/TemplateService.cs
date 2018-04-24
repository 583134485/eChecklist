using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;
using System.Collections.Generic;

namespace Gdc.Apps.Echecklist.Providers.Implement
{
    public class TemplateService:ITemplateService
    {
        private ITemplateRepositories templateRepositories;
        private const string SUCCESS = "01";
        private const string FAILTURE = "00";

        public TemplateService(ITemplateRepositories templateRepositories)
        {
            this.templateRepositories = templateRepositories;
        }

        public TemplateView GetAllTemplate()
        {
            TemplateView templateView = new TemplateView();
            List<Template> temp = this.templateRepositories.GetAllTemplate();
            templateView.StatusCode = SUCCESS;
            templateView.Data = temp;
            return templateView;
        }

        public TemplateView GetOneTemplate(Template template)
        {
            TemplateView templateView = new TemplateView();
            Template tem = this.templateRepositories.GetOneTemplate(template.Name, template.Type);
            if (tem==null)
            {
                templateView.StatusCode = FAILTURE;
            }
            else
            {
                templateView.StatusCode = SUCCESS;
                List<Template> tempaltes = new List<Template>();
                tempaltes.Add(tem);
                templateView.Data = tempaltes;
            }

            return templateView;
        }

        public TemplateView InsertTemplate(Template template)
        {
            TemplateView templateView = new TemplateView();
            /*   InstanceView ins = GetOneInstance(instance);
           if (SUCCESS.Equals(ins.statusCode))
           {
               instanceView.statusCode = FAILTURE;
           }
           else
           {
               instancedao.CreateInstance(instance);
               instanceView.statusCode = SUCCESS;
               instanceView.instance.Add(instance);
           }
           */
            bool result = this.templateRepositories.CreateTemplate(template);
            if (result)
            {
                templateView.StatusCode = SUCCESS;
                Template templateresult = this.templateRepositories.GetOneTemplate(template.Name, template.Type);
                List<Template> templatedata = new List<Template>();
                templatedata.Add(templateresult);
                templateView.Data = templatedata;
            }
            else
            {
                templateView.StatusCode = FAILTURE;
            }

            return templateView;
        }

        public TemplateView RemoveTemplate(Template template)
        {
            TemplateView templateView = new TemplateView();
            bool result = this.templateRepositories.Remove(template.Name);
            if (result)
            {
                templateView.StatusCode = SUCCESS;
            }
            else
            {
                templateView.StatusCode = FAILTURE;
            }

            return templateView;
        }

        public TemplateView UpdateTemplate(Template template)
        {
            TemplateView templateView = new TemplateView();
            bool result = this.templateRepositories.Update(template.Name, template);
            if (result)
            {
                List<Template> templatedata = new List<Template>();
                Template templateselect = this.templateRepositories.GetOneTemplate(template.Name, template.Type);
                templatedata.Add(templateselect);
                templateView.Data = templatedata;
                templateView.StatusCode = SUCCESS;
            }
            else
            {
                templateView.StatusCode = FAILTURE;
            }

            return templateView;
        }
    }
}
