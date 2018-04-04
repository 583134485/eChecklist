namespace WebApi.EChecklist.Repositories.Interface
{
    using System.Collections.Generic;
    using WebApi.EChecklist.Models.MongoModels;

    public interface ITemplateDao
    {
        List<Template> GetAllTemplate();

        Template GetOneTemplate(string name, string type);

        bool CreateTemplate(Template template);

        // bool CreateInstaneTemplate(string instance, string template);

        bool Update(string name, Template template);

        bool Remove(string name);
    }
}
