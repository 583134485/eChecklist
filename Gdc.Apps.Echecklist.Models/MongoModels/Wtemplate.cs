using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
  public  class Wtemplate
    {

        [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //ISOTate
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _c { get; set; }

        //ISOTate
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _m { get; set; }

        
        public BsonNull CreatedBy { get; set; }

        public BsonNull ModifiedBy { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool ActiveFlag { get; set; }

        public string Key { get; set; }

        public int Type { get; set; }


        public WTemplateValue Value { get; set; }

        public Wtemplate Children { get; set; }
    }
}
