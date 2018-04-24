using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Interface
{
    public interface IWtemplateService
    {
        ViewData<Wtemplate> GetDefaultWtemplate();
    }
}
