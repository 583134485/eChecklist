namespace WebApi.EChecklist.Models.ViewModels
{
    using System.Collections.Generic;
    using WebApi.EChecklist.Models.MongoModels;

    public class InstanceView
    {
        public string StatusCode { get; set; }

        public List<Instance> Data { get; set; }
    }
}
