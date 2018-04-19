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
   public class WTemplateRepositories : IWTemplateRepositories
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private static string Collection = "WTemplate";

        public WTemplateRepositories()
        {
            this.client = new MongoClient(ConfigurationManager.AppSettings["MongoIP"]);
            this.db = this.client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }
        public Wtemplate GetWtemplate()
        {
            return db.GetCollection<Wtemplate>(Collection).Find(_ =>true).FirstOrDefault();
        }
    }
}
