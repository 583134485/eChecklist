using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;

namespace Gdc.Apps.Echecklist.Providers.Interface
{
  public  interface IStepService
    {
        StepView GetAllSteps();

        StepView AddStep(Step step);

        StepView RemoveStep(Step step);

        StepView EditStep(Step step);

        StepView GetOneStepById(Step step);

        ViewData<Instance> GetInstanceByStep(Step step);

        StepView GetStepsByWorkflowId(Step step);


     }
}
