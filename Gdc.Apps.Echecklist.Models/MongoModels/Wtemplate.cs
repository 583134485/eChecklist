using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.MongoModels
{
    public class Wtemplate
    {
        // [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        //public string TemplateName {get;set;}

        //public string TemplateType { get; set; } 

        [BsonElement("Clazz")]
        public string Clazz { get; set; }

        [BsonElement("RowNum")]
        public int RowNum { get; set; }

        //public int X { get; set; }

        //public int Y { get; set; }


        [BsonElement("CreatedBy")]
        public string CreatedBy { get; set; }

        [BsonElement("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [BsonElement("ActiveFlag")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool ActiveFlag { get; set; }

        [BsonElement("Key")]
        public string Key { get; set; }

        [BsonElement("Type")]
        [BsonRepresentation(BsonType.Int32)]
        public int Type { get; set; }

        [BsonElement("Value")]
        public WTemplateValue Value { get; set; }

        //ISODate
        [BsonElement("_c")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _c { get; set; }

        //Date
        [BsonElement("_m")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _m { get; set; }

        [BsonElement("TemplateList")]
        public List<Wtemplate> TemplateList { get; set; }
       // public Wtemplate[] Children { get; set; }



        public override string ToString()
        {
            return "Template: " + _id
                + "Clazz: " + Clazz.ToJson()
                + "RowNum: " + RowNum.ToJson()
                + "_c: " + _c.ToString()
                + "_m: " + _m.ToString()
                + "ActiveFlag: " + ActiveFlag.ToJson()
                + "Key: " + Key.ToJson()
                + "Type: " + Type.ToJson()
                + "Value: " + Value.ToJson()
                + "TemplateList: " + TemplateList.ToJson()
                ;
        }
    }
}
