namespace WebApi.EChecklist.Models.ViewModels
{
    using System.Collections.Generic;
    using WebApi.EChecklist.Models.MongoModels;

    public class TemplateView
    {
        public string StatusCode { get; set; }

        public List<Template> Data { get; set; }
    }
}
