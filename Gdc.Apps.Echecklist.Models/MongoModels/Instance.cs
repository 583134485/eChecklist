

using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
    public class Instance
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
         
        [BsonElement("stepid")]
        public string stepid { get; set; }

    }
}
