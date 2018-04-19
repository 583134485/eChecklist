using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Models.ViewModels
{
    //view data for all model to web json
  public  class ViewData<T>
    {
        public string StatusCode { get; set; }

        //must be public if set to private cannot be see
        public List<T> Data;

        public List<T> GetData()
        {
            return Data;
        }

        public void SetData(List<T> value)
        {
            Data = value;
        }

        //overload setData
        public void SetData(T value)
        {
            List<T> list = new List<T>();
            list.Add(value);
            SetData(list);
        }
    }
}
