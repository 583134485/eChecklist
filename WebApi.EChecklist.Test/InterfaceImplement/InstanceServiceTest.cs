using NUnit.Framework;
using WebApi.EChecklist.Providers.InterfaceImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebApi.EChecklist.Models.MongoModels;
using WebApi.EChecklist.Models.ViewModels;
using WebApi.EChecklist.Repositories.Interface;

namespace WebApi.EChecklist.Providers.InterfaceImplement.Tests
{
    [TestFixture()]
    public class InstanceServiceTest
    {
        Mock<IInstanceDao> InstanceDaoMock = new Mock<IInstanceDao>();
        Mock<ITemplateDao> TemplateDaoMock = new Mock<ITemplateDao>();

        //2 new "Instance"  test case
        Instance ins1 = new Instance();
        Instance ins2 = new Instance();
        Template temp = new Template();

        List<Instance> instances = new List<Instance>();
        //view case
        InstanceView view = new InstanceView();

        //Receive the returned data.
        InstanceView _view = new InstanceView();

        private const string SUCCESS = "01";
        private const string FAILTURE = "00";

        //initialize 
        public void InitParamter(Instance ins1, Instance ins2)
        {
            ins1.Name = "TestCase1";
            ins1.Template = "TestCase1";
            ins1.Type = "T1";

            ins2.Name = "TestCase2";
            ins2.Template = "T2";
            ins2.Type = "T2";
        }

        public void ChangeViewData(Instance ins, List<Instance> instances, InstanceView view)
        {
            instances.Add(ins);
            view.Data = instances;
            view.StatusCode = SUCCESS;
        }

        public void InitTemp(Template temp)
        {
            temp.Name = "TestCase1";
            temp.Type = "T1";
        }

        [Test()]
        public void InstanceServiceImpTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetAllInstanceTest()
        {
            InitParamter(ins1, ins2);

            ChangeViewData(ins1, instances, view);
            ChangeViewData(ins2, instances, view);


            InstanceDaoMock.Setup(f => f.GetAllInstance()).Returns(view.Data);
            //TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Name, ins1.Type)).Returns(temp);

            InstanceServiceImp impl = new InstanceServiceImp(InstanceDaoMock.Object, TemplateDaoMock.Object);

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
            //initialize the test data
            InitParamter(ins1, ins2);
            ChangeViewData(ins1, instances, view);

            //mock the Obj method
            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type)).Returns(ins1);

            //
            InstanceServiceImp impl = new InstanceServiceImp(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.GetOneInstance(ins1);

            //
            Assert.IsNotNull(_view);
            Assert.AreEqual(view.StatusCode, _view.StatusCode);
            Assert.AreEqual(view.Data.Count, _view.Data.Count);
        }

        [Test()]
        public void InsertInstanceTest()
        {
            InitParamter(ins1, ins2);
            InitTemp(temp);

            InstanceDaoMock.Setup(f => f.CreateInstance(It.IsAny<Instance>())).Returns(true);
            InstanceDaoMock.Setup(f => f.GetOneInstance(ins1.Name, ins1.Type)).Returns(ins1);
            TemplateDaoMock.Setup(f => f.GetOneTemplate(ins1.Template, ins1.Type)).Returns(temp);
            // InstanceDaoMock.Setup(f => f.CreateInstance(ins1)).Returns(false);

            InstanceServiceImp impl = new InstanceServiceImp(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.InsertInstance(ins1);

            Assert.IsNotNull(_view);
            // Assert.AreEqual(FAILTURE, _view.StatusCode);
            Assert.AreEqual(SUCCESS, _view.StatusCode);
            Assert.AreEqual(1, _view.Data.Count);

        }

        [Test()]
        public void RemoveIntanceTest()
        {
            InitParamter(ins1, ins2);

            InstanceDaoMock.Setup(f => f.Remove(ins1.Name)).Returns(true);

            InstanceServiceImp impl = new InstanceServiceImp(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.RemoveIntance(ins1);

            //judge the name 
            foreach (Instance ins in _view.Data)
            {
                Assert.AreEqual(ins.Name, ins1.Name);
            }

            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);


        }

        [Test()]
        public void UpdateIntanceTest()
        {

            InitParamter(ins1, ins2);

            InstanceDaoMock.Setup(f => f.Update(ins1.Name, ins1)).Returns(true);

            InstanceServiceImp impl = new InstanceServiceImp(InstanceDaoMock.Object, TemplateDaoMock.Object);

            _view = impl.UpdateIntance(ins1);

            Assert.IsNotNull(_view);
            Assert.AreEqual(SUCCESS, _view.StatusCode);

        }

    }
}