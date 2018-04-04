namespace WebApi.EChecklist.Repositories.InterfaceImplement
{
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver;
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Repositories.Interface;

    public class InstanceDaoImp : IInstanceDao
    {
        private MongoClient client;
        private IMongoDatabase db;
        private static string Collection = "Instance";

        public InstanceDaoImp()
        {
            this.client = new MongoClient("mongodb://localhost:27017");
            this.db = this.client.GetDatabase("eChecklist");
        }

        public bool CreateInstance(Instance instance)
        {
            this.db.GetCollection<Instance>(Collection).InsertOne(instance);
            return true;
        }

        public bool CreateInstanceTemplate(string instancename, string templatename)
        {
            Instance a = this.GetOneInstance(instancename, templatename);
            a.Template = templatename;
            this.db.GetCollection<Instance>(Collection).ReplaceOne(c => c.Name == instancename, a);
            return true;
        }

        public List<Instance> GetAllInstance()
        {
            return this.db.GetCollection<Instance>(Collection).Find(_ => true).ToEnumerable().ToList();
        }

        public Instance GetOneInstance(string name, string type)
        {
            return this.db.GetCollection<Instance>(Collection).Find(c => c.Name == name).FirstOrDefault();
        }

        public bool Remove(string name)
        {
            this.db.GetCollection<Instance>(Collection).DeleteOne(c => c.Name == name);
            return true;
        }

        public bool Update(string name, Instance instance)
        {
            Instance a = this.GetOneInstance(name, string.Empty);
            a.Template = instance.Template;
            a.Type = instance.Type;
            this.db.GetCollection<Instance>(Collection).ReplaceOne(c => c.Name == name, a);
            return true;
        }
    }
}
