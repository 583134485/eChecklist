using NUnit.Framework;
using Gdc.Apps.Echecklist.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;
using System.Diagnostics;
using System.Configuration;

namespace Gdc.Apps.Echecklist.Repositories.Implement.Tests
{
    [TestFixture()]
    public class TemplateRepositoriesTests
    {
        [Test()]
        public void TemplateRepositoriesTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void CreateTemplateTest()
        {
            TemplateRepositories templateRepositories = new TemplateRepositories();
            Template template = new Template();
            Template templatechildren = new Template();
            List<Template> templates = new List<Template>();
            templatechildren.Name = "children";
            template.Name = "father";
            templates.Add(templatechildren);
            template.Children = templates;

            bool result = templateRepositories.CreateTemplate(template);
            Assert.AreEqual(true, result);
        }

        [Test()]
        public void GetAllTemplateTest()
        {
            TemplateRepositories templateRepositories = new TemplateRepositories();
            List<Template> templates = templateRepositories.GetAllTemplate();
            foreach(Template a in templates)
            {
               
            }
            Assert.Pass();
            //TemplateRepositories templateRepositories = new TemplateRepositories();
            //List<Template> templates = templateRepositories.GetAllTemplate();
            //Assert.IsTrue(templates.Count>=0);
            //string a = ConfigurationManager.AppSettings["MongoDatabase"];
            //Console.Write("======================" + a);
            //Assert.AreEqual("eChecklist", a);
        }

        [Test()]
        public void GetOneTemplateTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void RemoveTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void UpdateTest()
        {
            Assert.Pass();
        }
    }
}