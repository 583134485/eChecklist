namespace WebApi.EChecklist.Repositories.Interface
{
    using System.Collections.Generic;
    using WebApi.EChecklist.Models.MongoModels;

    public interface IInstanceDao
    {
        List<Instance> GetAllInstance();

        Instance GetOneInstance(string name, string type);

        bool CreateInstance(Instance instance);

        bool CreateInstanceTemplate(string instaceid, string templateid);

        // bool CreateInstaneTemplate(string instance, string template);
        bool Update(string name, Instance instance);

        bool Remove(string name);
    }
}
