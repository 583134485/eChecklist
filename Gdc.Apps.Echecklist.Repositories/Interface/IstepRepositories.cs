using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;

namespace Gdc.Apps.Echecklist.Repositories.Interface
{
  public  interface IStepRepositories
    {
        List<Step> GetAllStep();

        bool CreateStep(Step step);

       // bool CreateInstance(Instance instance);

        //bool CreateInstanceTem(string instaceid, string templateid);

        // bool CreateInstaneTemplate(string instance, string template);
        bool Update(Step step);

        bool Remove(Step step);

        Step GetOneStepByName(Step step);

        Step GetOneStepById(Step step);

        List<Step> GetStepsByWorkflowId(string id);
        Step GetOneStepByNameAndWorkflowId(Step step);
    }
}
