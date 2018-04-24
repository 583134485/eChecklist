using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Interface
{
   public interface IWorkflowService
    {
        ViewData<Workflow> GetAllWorkflow();

        ViewData<Workflow> GetOneWorkflow(Workflow workflow);

        ViewData<Workflow> InsertWorkflow(Workflow workflow);

        ViewData<Step> GetStepsByWorkflow(Workflow workflow);
        //通过step 数据表 记录的 
        ViewData<Step> GetStepsByWorkflowId(Workflow workflow);

        // addtemplate and  updateinstance  in this method
        ViewData<Workflow> UpdateWorkflow(Workflow workflow);

        ViewData<Workflow> RemoveWorkflow(Workflow workflow);

    }
}
