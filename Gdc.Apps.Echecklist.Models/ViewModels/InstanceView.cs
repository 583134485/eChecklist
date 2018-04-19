using Gdc.Apps.Echecklist.Models.MongoModels;
using System.Collections.Generic;

namespace Gdc.Apps.Echecklist.Models.ViewModels
{

    public class InstanceView
    {
        public string StatusCode { get; set; }

        public List<Instance> Data { get; set; }
    }
}
