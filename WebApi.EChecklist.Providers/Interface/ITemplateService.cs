namespace WebApi.EChecklist.Providers.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Models.ViewModels;

    public interface ITemplateService
    {
        TemplateView GetAllTemplate();

        TemplateView GetOneTemplate(Template template);

        TemplateView InsertTemplate(Template template);

        // addtemplate and  updateinstance  in this method
        TemplateView UpdateTemplate(Template template);

        TemplateView RemoveTemplate(Template template);
    }
}
