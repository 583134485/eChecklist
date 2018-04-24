
namespace Gdc.Apps.Echecklist.Repositories.Interface
{
    using Gdc.Apps.Echecklist.Models.MongoModels;
    using MongoDB.Bson;
    using System.Collections.Generic;

    public interface IInstanceRepositories
    {
        List<Instance> GetAllInstance();

        Instance GetOneInstance(string name, string type);

        bool CreateInstance(Instance instance);

        bool CreateInstanceTemplate(string instancename, string templatename);

        // bool CreateInstaneTemplate(string instance, string template);
        bool Update(Instance newinstance);

        bool Remove(string objectId);

        bool InsertBarch(List<Instance> instances);

        List<Instance> GetSomeInstanceByStepId(string id);

        bool InsertIstanceforStep(Instance instance);

        bool EditIstanceforStep(Instance instance);

        Instance GetInstanceById(string objectId);
    }
}
