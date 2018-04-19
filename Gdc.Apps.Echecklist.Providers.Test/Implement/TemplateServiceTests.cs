using NUnit.Framework;
using Gdc.Apps.Echecklist.Providers.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Repositories.Interface;

namespace Gdc.Apps.Echecklist.Providers.Implement.Tests
{
    [TestFixture()]
    public class TemplateServiceTests
    {
        Mock<ITemplateRepositories> TemplateDaoMock = new Mock<ITemplateRepositories>();
        private const string SUCCESS = "01";
        private const string FAILTURE = "00";

        //2 new "Instance"  test case
        Template temp1 = new Template();
        Template temp2 = new Template();

        List<Template> templates = new List<Template>();
        TemplateView view = new TemplateView();

        //Receive the returned data.
        TemplateView _view = new TemplateView();

        public void InitParamter(Template temp1, Template temp2, List<Template> templates)
        {
            temp1.Name = "template1";
            temp1.Type = "T1";

            temp2.Name = "template2";
            temp2.Type = "T2";
            templates.Clear();
        }

        public void ChangeViewData(Template temp, List<Template> templates, TemplateView view)
        {
            templates.Add(temp);
            view.Data = templates;
            view.StatusCode = SUCCESS;
        }

        [Test()]
        public void TemplateServiceTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void GetAllTemplateTest()
        {
            InitParamter(temp1, temp2,templates);
            ChangeViewData(temp1, templates, view);
            ChangeViewData(temp2, templates, view);

            TemplateDaoMock.Setup(f => f.GetAllTemplate()).Returns(view.Data);
            TemplateService impl = new TemplateService(TemplateDaoMock.Object);

            _view = impl.GetAllTemplate();

            Assert.IsNotNull(_view);
            Assert.AreEqual(view.StatusCode, _view.StatusCode);
            Assert.AreEqual(view.Data.Count, _view.Data.Count);
            Assert.AreEqual(2, _view.Data.Count);
        }

        [Test()]
        public void GetOneTemplateTest()
        {
            InitParamter(temp1, temp2, templates);
            ChangeViewData(temp1, templates, view);
            Template tem3 = new Template();
            tem3 = null;

            TemplateDaoMock.Setup(f => f.GetOneTemplate(temp1.Name, temp1.Type)).Returns(temp1);
            TemplateService impl = new TemplateService(TemplateDaoMock.Object);
            _view = impl.GetOneTemplate(temp1);
            //
            TemplateDaoMock.Setup(f => f.GetOneTemplate(temp1.Name, temp1.Type)).Returns(tem3);
            TemplateView tem_v = impl.GetOneTemplate(temp1);
            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);
            Assert.AreEqual(1, _view.Data.Count);
        }

        [Test()]
        public void InsertTemplateTest()
        {
            Template tem3 = new Template();
            tem3 = null;
            InitParamter(temp1, temp2, templates);
            TemplateDaoMock.Setup(f => f.CreateTemplate(temp1)).Returns(true);
            TemplateDaoMock.Setup(f => f.GetOneTemplate(temp1.Name, temp1.Type)).Returns(temp1);
            
            //TemplateDaoMock.Setup(f => f.CreateTemplate(temp1)).Returns(false);

            TemplateService impl = new TemplateService(TemplateDaoMock.Object);

            _view = impl.InsertTemplate(temp1);
            //
            TemplateDaoMock.Setup(f => f.CreateTemplate(temp1)).Returns(false);
            TemplateView tem_v = impl.InsertTemplate(temp1);
            // Assert.AreEqual(FAILTURE, _view.StatusCode);
            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);
            Assert.AreEqual(1, _view.Data.Count);
            Assert.AreEqual(true, _view.Data.Contains(temp1));
        }

        [Test()]
        public void RemoveTemplateTest()
        {
            InitParamter(temp1, temp2, templates);
            TemplateDaoMock.Setup(f => f.Remove(temp1.Name)).Returns(true);
            // TemplateDaoMock.Setup(f => f.Remove(temp1.Name)).Returns(false);

            TemplateService impl = new TemplateService(TemplateDaoMock.Object);
            _view = impl.RemoveTemplate(temp1);

            TemplateDaoMock.Setup(f => f.Remove(temp1.Name)).Returns(false);
            TemplateView tem_v = impl.RemoveTemplate(temp1);
            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);
            // Assert.AreEqual(FAILTURE, _view.StatusCode);
        }

        [Test()]
        public void UpdateTemplateTest()
        {
            InitParamter(temp1, temp2, templates);
            TemplateDaoMock.Setup(f => f.Update(temp1.Name, temp1)).Returns(true);
            TemplateDaoMock.Setup(f => f.GetOneTemplate(temp1.Name, temp1.Type)).Returns(temp1);
            TemplateService impl = new TemplateService(TemplateDaoMock.Object);
            _view = impl.UpdateTemplate(temp1);
            TemplateDaoMock.Setup(f => f.Update(temp1.Name, temp1)).Returns(false);
            TemplateView tem_v = impl.UpdateTemplate(temp1);

            foreach (Template template in _view.Data)
            {
                Assert.AreEqual(template.Name, temp1.Name);
            }

          
            Assert.AreEqual(SUCCESS, _view.StatusCode);
        }
    }
}