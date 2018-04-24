using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
    public class WTemplateValue
    {
        [BsonElement("_t")]
        public string _t { get; set; }

        [BsonElement("Texts")]
        // public List<TemplateTexts> Texts { get; set; }
        public TemplateTexts[] Texts { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("DataSource")]
        public string DataSource { get; set; }

        public override string ToString()
        {

            return "_t: " + _t + "Texts: " + Texts.ToJson();
             

        }
    }
}
