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
        public string _t { get; set; }

       [BsonIgnoreIfNull]
        public List<TemplateTexts> Texts { get; set; }
        //public TemplateTexts[] Texts { get; set; }
    }
}
