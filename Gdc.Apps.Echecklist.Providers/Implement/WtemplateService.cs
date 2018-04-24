
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Implement
{
    public class WtemplateService : IWtemplateService
    {
        private readonly IWTemplateRepositories wTemplateRepositories;
        private const string SUCCESS = "01";
        private const string FAIL = "00";
        private const string REPETITION = "02";
        private const string EXCEPTION = "99";

        public WtemplateService(IWTemplateRepositories wTemplateRepositories)
        {
            this.wTemplateRepositories = wTemplateRepositories;
        }

        public ViewData<Wtemplate> GetDefaultWtemplate()
        {
            ViewData<Wtemplate> viewData = new ViewData<Wtemplate>();
            try
            {
                Wtemplate wtemplate = wTemplateRepositories.GetWtemplate();
                viewData.StatusCode = SUCCESS;
                viewData.SetData(wtemplate);
            }
            catch(Exception e)
            {
                Console.Write(e);
                viewData.StatusCode = EXCEPTION;
                
            }
            return viewData;
        }


    }
}
