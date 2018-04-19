using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Repositories.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace Gdc.Apps.Echecklist.Repositories.Implement
{
   public class TemplateRepositories: ITemplateRepositories
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private const string Collection = "Template";

        public TemplateRepositories()
        {
            this.client = new MongoClient(ConfigurationManager.AppSettings["MongoIP"]);
            this.db = this.client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }

        public bool CreateTemplate(Template template)
        {
            this.db.GetCollection<Template>(Collection).InsertOne(template);
            return true;
        }

        public List<Template> GetAllTemplate()
        {
            return this.db.GetCollection<Template>(Collection).Find(_ => true).SortBy(x=>x.Name).ToEnumerable().ToList();
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
