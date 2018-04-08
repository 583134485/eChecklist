namespace WebApi.EChecklist.Providers.InterfaceImplement
{
    using System.Collections.Generic;
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Models.ViewModels;
    using WebApi.EChecklist.Providers.Interface;
    using WebApi.EChecklist.Repositories.Interface;

    public class TemplateServiceImp : ITemplateService
    {
        private ITemplateDao templatedao;
        private const string SUCCESS = "01";
        private const string FAILTURE = "00";

        // public TemplateServiceImp()
        // {
        //    templatedao = new TemplateDaoImpl();
        // }
        public TemplateServiceImp(ITemplateDao templatedao)
        {
            this.templatedao = templatedao;
        }

        public TemplateView GetAllTemplate()
        {
            TemplateView templateView = new TemplateView();
            List<Template> temp = this.templatedao.GetAllTemplate();
            templateView.StatusCode = SUCCESS;
            templateView.Data = temp;
            return templateView;
        }

        public TemplateView GetOneTemplate(Template template)
        {
            TemplateView templateView = new TemplateView();
            Template tem = this.templatedao.GetOneTemplate(template.Name, template.Type);
            if (string.IsNullOrEmpty(tem.Name))
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
            bool result = this.templatedao.CreateTemplate(template);

            // Console.Write();
            if (result)
            {
                templateView.StatusCode = SUCCESS;
                Template templateresult = this.templatedao.GetOneTemplate(template.Name, template.Type);
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
            bool result = this.templatedao.Remove(template.Name);
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
            bool result = this.templatedao.Update(template.Name, template);
            if (result)
            {
                List<Template> templatedata = new List<Template>();
                Template templateselect = this.templatedao.GetOneTemplate(template.Name, template.Type);
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
