using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Repositories.Interface;
using MongoDB.Driver;

namespace Gdc.Apps.Echecklist.Repositories.Implement
{
   public  class StepRepositories : IStepRepositories
    {

        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private static string Collection = "Step";
        public StepRepositories()
        {
            this.client = new MongoClient(ConfigurationManager.AppSettings["MongoIP"]);
            this.db = this.client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }
        public List<Step> GetAllStep()
        {
            return this.db.GetCollection<Step>(Collection).Find(_ => true).SortBy(x => x.Name).ToEnumerable().ToList();  
        }

        public bool CreateStep(Step step)
        {
            this.db.GetCollection<Step>(Collection).InsertOne(step);  
            return true;
        }

        public bool Remove(Step step)
        {
            this.db.GetCollection<Step>(Collection).DeleteOne(x => x.Id ==step.Id);
            return true;
        }

        public bool Update(Step step)
        {
            this.db.GetCollection<Step>(Collection).ReplaceOne(x => x.Id == step.Id, step);
            return true;
        }

        public Step GetOneStepByName(Step step)
        {
           return this.db.GetCollection<Step>(Collection).Find(x => x.Name == step.Name).FirstOrDefault();
            
        }

        public Step GetOneStepById(Step step)
        {
            return this.db.GetCollection<Step>(Collection).Find(x => x.Id == step.Id).FirstOrDefault();
        }

        public List<Step> GetStepsByWorkflowId(string id)
        {
            return this.db.GetCollection<Step>(Collection).Find(x => x.Id == id).ToEnumerable().ToList();
            // throw new NotImplementedException();
        }
    }
}
