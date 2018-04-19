


namespace Gdc.Apps.Echecklist.Repositories.Interface
{
    using Gdc.Apps.Echecklist.Models.MongoModels;
    using System.Collections.Generic;

    public interface ITemplateRepositories
    {
        List<Template> GetAllTemplate();

        Template GetOneTemplate(string name, string type);

        bool CreateTemplate(Template template);

        // bool CreateInstaneTemplate(string instance, string template);

        bool Update(string name, Template template);

        bool Remove(string name);
    }
}
