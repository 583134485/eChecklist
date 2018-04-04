

namespace WebApi.EChecklist.Repositories.InterfaceImplement
{
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver;
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Repositories.Interface;

    public class TemplateDaoImp : ITemplateDao
    {
        private MongoClient client;
        private IMongoDatabase db;
        private const string Collection = "Template";

        public TemplateDaoImp()
        {
            this.client = new MongoClient("mongodb://localhost:27017");
            this.db = this.client.GetDatabase("eChecklist");
        }

        public bool CreateTemplate(Template template)
        {
            this.db.GetCollection<Template>(Collection).InsertOne(template);
            return true;
        }

        public List<Template> GetAllTemplate()
        {
            return this.db.GetCollection<Template>(Collection).Find(_ => true).ToEnumerable().ToList();
        }

        public Template GetOneTemplate(string name, string type)
        {
            return this.db.GetCollection<Template>(Collection).Find(c => c.Name == name).FirstOrDefault();
        }

        public bool Remove(string name)
        {
            this.db.GetCollection<Template>(Collection).DeleteOne(c => c.Name == name);
            return true;
        }

        public bool Update(string name, Template template)
        {
            Template a = this.GetOneTemplate(name, string.Empty);
            a.Name = template.Name;
            a.Type = template.Type;
            this.db.GetCollection<Template>(Collection).ReplaceOne(c => c.Name == name, a);
            return true;
        }
    }
}
