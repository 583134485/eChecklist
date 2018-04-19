
using Gdc.Apps.Echecklist.Models.MongoModels;
using System.Collections.Generic;

namespace Gdc.Apps.Echecklist.Models.ViewModels
{
    public class TemplateView
    {
        public string StatusCode { get; set; }

        public List<Template> Data { get; set; }
    }
}
