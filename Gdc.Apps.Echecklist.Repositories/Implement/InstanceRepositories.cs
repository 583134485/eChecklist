using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Repositories.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Repositories.Implement
{
   public class InstanceRepositories :IInstanceRepositories
    {
        private  readonly MongoClient client;
        private  readonly IMongoDatabase db;
        private static string Collection = "Instance";

        public InstanceRepositories()
        {
            this.client = new MongoClient(ConfigurationManager.AppSettings["MongoIP"]);
            this.db = this.client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }

        public bool CreateInstance(Instance instance)
        {
            if (instance.Name == null)
            {
                return false;
            }
            else
            {
                this.db.GetCollection<Instance>(Collection).InsertOne(instance);
            }
           
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
            return this.db.GetCollection<Instance>(Collection).Find(_ => true).SortBy(x=>x.Name).ToEnumerable().ToList();
        }

        public Instance GetOneInstance(string name, string type)
        {
            return this.db.GetCollection<Instance>(Collection).Find(c => c.Name == name).FirstOrDefault();
        }

        public bool Remove(string objectId)
        {
            this.db.GetCollection<Instance>(Collection).DeleteOne(c => c.Id == objectId);
            return true;
        }
        public Instance GetInstanceById(string objectId)
        {
            return this.db.GetCollection<Instance>(Collection).Find(x => x.Id == objectId).FirstOrDefault();
            
        }

        //access that  instance is exits so  wo put more details in service 
        //find instance fisrt then update
        public bool Update(Instance newinstance)
        {
            //temp data
            Instance instance = new Instance();
            bool result = false;        
           
                instance = this.db.GetCollection<Instance>(Collection).Find(c => c.Id == newinstance.Id ).FirstOrDefault();
            //not find instance 
            if (instance == null)
            {
                result = false;
            }
            // update finally
            else
            {
                
                instance.Name = newinstance.Name;
                instance.Template = newinstance.Template;
                instance.Type = newinstance.Type;
                this.db.GetCollection<Instance>(Collection).ReplaceOne(c => c.Id == instance.Id, instance);
                result = true;
            }
            return result;
        }

        public bool InsertBarch(List<Instance> instances)
        {
            db.GetCollection<Instance>(Collection).InsertMany(instances);
            return true;
        }

        public List<Instance> GetSomeInstanceByStepId(string id)
        {
            return db.GetCollection<Instance>(Collection).Find(x => x.stepid == id).ToEnumerable().ToList();
        }

        public bool InsertIstanceforStep(Instance instance)
        {

            db.GetCollection<Instance>(Collection).InsertOne(instance);
            return true;
        }


        public bool EditIstanceforStep(Instance instance)
        {
           db.GetCollection<Instance>(Collection).ReplaceOne(c => c.Id == instance.Id, instance);
            return true;
        }
       
    }
}
