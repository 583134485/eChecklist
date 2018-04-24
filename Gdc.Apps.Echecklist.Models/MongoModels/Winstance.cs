using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
   public class Winstance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("template")]
        public string Template { get; set; }
    }
}
