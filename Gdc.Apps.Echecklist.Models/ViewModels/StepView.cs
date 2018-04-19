using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;

namespace Gdc.Apps.Echecklist.Models.ViewModels
{
  public  class StepView
    {
       
        public string StatusCode { get; set; }

        public List<Step> Data;
        public List<Step> GetData()
        {
            return Data;
        }

        public void SetData(List<Step> value)
        {
            Data = value;
        }

        //overload setData
        public void SetData(Step value)
        {
            List<Step> list = new List<Step>();
            list.Add(value);
            SetData(list);
        }

    }
}
