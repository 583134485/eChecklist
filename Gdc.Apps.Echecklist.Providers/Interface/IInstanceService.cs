using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Interface
{
    public interface IInstanceService
    {
        InstanceView GetAllInstance();

        InstanceView GetOneInstance(Instance instance);

        InstanceView InsertInstance(Instance instance);

        // just for debug not for function useless
        InstanceView InsertBatchInsert(Instance instances);

        // addtemplate and  updateinstance  in this method
        InstanceView UpdateIntance(Instance instance);

        InstanceView RemoveIntance(Instance instance);


        InstanceView InsertInstanceForStep(Instance instance);

        //InstanceView 

  
    }
}
