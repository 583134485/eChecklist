using NUnit.Framework;
using Gdc.Apps.Echecklist.Providers.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gdc.Apps.Echecklist.Models;
using Gdc.Apps.Echecklist.Repositories.Interface;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Repositories.Implement;

namespace Gdc.Apps.Echecklist.Providers.Implement.Tests
{
    [TestFixture()]
    public class InstanceServiceTests
    {
        Mock<IInstanceRepositories> InstanceDaoMock = new Mock<IInstanceRepositories>();

        Mock<ITemplateRepositories> TemplateDaoMock = new Mock<ITemplateRepositories>();

        //2 new "Instance"dd d test dd dd dd ss s case
        Instance ins1 = new Instance();
        Instance ins2 = new Instance();
        Instance ins3 = new Instance();
        Template temp = new Template();
        Template temp_ = new Template();
        List<Instance> instances = new List<Instance>();
        //view case
        InstanceView view = new InstanceView();

        //Receive the returned data.
        InstanceView _view = new InstanceView();

        private const string SUCCESS = "01";
        private const string FAILTURE = "00";
        private const string REPETITION = "02";

        //initialize 
        public void InitParamter(Instance ins1, Instance ins2, Instance ins3, List<Instance> instances)
        {
            ins1.Id = "5ac9a0ec104ccb5170e7a42a";
            ins1.Name = "TestCase1";
            ins1.Template = "TestCase1";
            ins1.Type = "T1";

            ins2.Id = "5ac9a0ec104ccb5170e7aasa";
            ins2.Name = "TestCase2";
            ins2.Template = "T2";
            ins2.Type = "T2";

            ins3 = null;

            instances.Clear();
        }

        public void ChangeViewData(Instance ins, List<Instance> instances, InstanceView view)
        {
            instances.Add(ins);
            view.Data = instances;
            view.StatusCode = SUCCESS;
        }

        public void InitTemp(Template temp, Template temp_)
        {
            temp.Name = "TestCase1";
            temp.Type = "T1";
            temp_ = null;
        }

        public void InitData()
        {
            InitParamter(ins1, ins2, ins3, instances);
            ChangeViewData(ins1, instances, view);
            ChangeViewData(ins2, instances, view);
            InitTemp(temp, temp_);
        }



        [Test()]
        public void InstanceServiceTest()
        {

        }

        [Test()]
        public void GetAllInstanceTest()
        {
            /*InitParamter(ins1, ins2, instances);
            ChangeViewData(ins1, instances, view);
            ChangeViewData(ins2, instances, view);*/
            InitData();


            InstanceDaoMock.Setup(f => f.GetAllInstance()).Returns(view.Data);
            //TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Name, ins1.Type)).Returns(temp);

            InstanceService impl = new InstanceService(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.GetAllInstance();

            //
            Assert.IsNotNull(_view);
            Assert.AreEqual(view.StatusCode, _view.StatusCode);
            Assert.AreEqual(view.Data.Count, _view.Data.Count);
            Assert.AreEqual(2, _view.Data.Count);
        }

        [Test()]
        public void GetOneInstanceTest()
        {
            InitData();

            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type))
                .Returns(ins1);

            InstanceDaoMock.Setup(f => f.GetOneInstance(ins2.Name, ins2.Type))
               .Returns(ins3);
            //
            InstanceService impl = new InstanceService(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.GetOneInstance(ins1);

            //
            Assert.IsNotNull(_view);
            Assert.AreEqual(view.StatusCode, _view.StatusCode);
            Assert.AreEqual(view.Data.Count, _view.Data.Count);

            _view = impl.GetOneInstance(ins2);
            Assert.AreEqual(FAILTURE, _view.StatusCode);
        }

        [Test()]
        public void InsertInstanceTest()
        {
            InitData();
            Instance ins4 = new Instance();
            ins4.Id = "5ac9a0a42a";
            ins4.Name = "TestCase4";
            ins4.Template = "TestCase4";
            ins4.Type = "T4";

            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins2.Template, ins2.Type))
                .Returns(temp_);

            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Template, ins1.Type))
                .Returns(temp);

            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins4.Template, ins4.Type))
                .Returns(temp);


            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type))
               .Returns(ins1);

            InstanceDaoMock.Setup(f => f.GetOneInstance(ins2.Name, ins2.Type))
               .Returns(ins2);

            InstanceDaoMock.Setup(f => f.GetOneInstance(ins4.Name, ins4.Type))
               .Returns(ins3);

            InstanceDaoMock.Setup(f => f.CreateInstance(It.IsAny<Instance>()))
               .Returns(true);

            InstanceService impl = new InstanceService(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.InsertInstance(ins1);
            Assert.AreEqual(REPETITION, _view.StatusCode);

            _view = impl.InsertInstance(ins2);
            Assert.AreEqual(FAILTURE, _view.StatusCode);

            _view = impl.InsertInstance(ins4);
            Assert.AreEqual(SUCCESS, _view.StatusCode);

        }

        [Test()]
        public void RemoveIntanceTest()
        {
            InitData();

            InstanceDaoMock.Setup(f => f.Remove(ins1.Id)).Returns(true);
            InstanceDaoMock.Setup(f => f.Remove(ins2.Id)).Returns(false);

            InstanceService impl = new InstanceService(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.RemoveIntance(ins1);

            //judge the name 
            foreach (Instance ins in _view.Data)
            {
                Assert.AreEqual(ins.Name, ins1.Name);
            }
            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);

            _view = impl.RemoveIntance(ins2);
            Assert.AreEqual(FAILTURE, _view.StatusCode);

        }

        [Test()]
        public void UpdateIntanceTest()
        {
            InitData();

            InstanceDaoMock.Setup(f => f.Update(ins1)).Returns(true);
            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Template, It.IsAny<String>())).Returns(temp);
            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type)).Returns(ins1);
            InstanceService impl = new InstanceService(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.UpdateIntance(ins1);
            //
            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Template, It.IsAny<String>()))
                .Returns(temp_);
            InstanceView ins_v = impl.UpdateIntance(ins1);

            //
            InstanceDaoMock.Setup(f => f.Update(ins1)).Returns(true);
            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Template, It.IsAny<String>())).Returns(temp);
            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type)).Returns(ins3);
            InstanceView ins_v2 = impl.UpdateIntance(ins1);

            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);
        }

    }
}