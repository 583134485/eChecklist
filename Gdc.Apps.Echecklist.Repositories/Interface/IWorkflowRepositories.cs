using Gdc.Apps.Echecklist.Models.MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Repositories.Interface
{
    public interface IWorkflowRepositories
    {
        List<Workflow> GetAll();

        Workflow GetOne(Workflow workflow);

        Workflow GetOneById(string id);

        bool Insert(Workflow workflow);
     
        bool Update(Workflow workflow);

        bool Remove(string Id);


    }
}
