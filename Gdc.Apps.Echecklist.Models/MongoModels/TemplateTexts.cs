using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
    public class TemplateTexts
    {
        //public  TextsValue textsValues;
        [BsonElement("Language")]
        public string Language { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        public override string ToString()
        {
            return "Language: " + Language.ToString() + "Content: " + Content.ToString();
        }
    }
}
