using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Repositories.Implement
{
    public class WorkflowRepositories : IWorkflowRepositories
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private static string Collection = "Workflow";

        public WorkflowRepositories()
        {
            this.client = new MongoClient(ConfigurationManager.AppSettings["MongoIP"]);
            this.db = this.client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }
        public List<Workflow> GetAll()
        {
            return this.db.GetCollection<Workflow>(Collection).Find(_ => true).SortBy(x => x.Name).ToEnumerable().ToList();
        }

        public Workflow GetOne(Workflow workflow)
        {
            return this.db.GetCollection<Workflow>(Collection).Find(c => c.Name == workflow.Name).FirstOrDefault();
        }

        public Workflow GetOneByName(String name)
        {
            return this.db.GetCollection<Workflow>(Collection).Find(c => c.Name == name).FirstOrDefault();
        }

        public bool Insert(Workflow workflow)
        {
            workflow.Modifiedtime = DateTime.Now;
            this.db.GetCollection<Workflow>(Collection).InsertOne(workflow);
            return true;
        }

        public bool Remove(string Id)
        {
            this.db.GetCollection<Workflow>(Collection).DeleteOne(c => c.Id == Id);
            return true;
        }

        public bool Update(Workflow workflow)
        {
            workflow.Modifiedtime = DateTime.Now;
            this.db.GetCollection<Workflow>(Collection).ReplaceOne(c => c.Id == workflow.Id, workflow);

            return true;
        }

        public Workflow GetOneById(string id)
        {
            return this.db.GetCollection<Workflow>(Collection).Find(c => c.Id == id).FirstOrDefault();
        }
    }
}
