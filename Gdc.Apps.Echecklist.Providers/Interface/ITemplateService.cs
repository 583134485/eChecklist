using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Interface
{
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
