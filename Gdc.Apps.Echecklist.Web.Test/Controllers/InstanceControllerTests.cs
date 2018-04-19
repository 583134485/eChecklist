using NUnit.Framework;
using Moq;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;

namespace Gdc.Apps.Echecklist.Web.Controllers.Tests
{
    [TestFixture()]
    public class InstanceControllerTests
    {
        Instance ins1 = new Instance();
        Instance ins2 = new Instance();
        Instance insJ = new Instance();
        public void InitParamter(Instance ins1, Instance ins2)
        {
            ins1.Id = "5ac9a0ec104ccb5170e7a42a";
            ins1.Name = "TestCase1";
            ins1.Template = "TestCase1";
            ins1.Type = "T1";

            ins2.Id = "5ac9a0ec104ccb5170e7a42a";
            ins2.Name = "TestCase2";
            ins2.Template = "T2";
            ins2.Type = "T2";

           // instances.Clear();
        }
        public void InitParamter(Instance ins1)
        {
            ins1.Id = "5ac9a0ec104ccb5170e7a42a";
            ins1.Name = "TestCase2";
            ins1.Template = "TestCase2";
            ins1.Type = "T2";
        }
        [Test()]
        public void InstanceControllerTest()
        {

        }

        [Test()]
        public void GetAllInstanceTest()
        {
            InstanceView instanceView = new InstanceView();
            instanceView.StatusCode = "66";
            Mock<IInstanceService> instanceServiceMock = new Mock<IInstanceService>();
            instanceServiceMock.Setup(f => f.GetAllInstance()).Returns(instanceView);

            InstanceController instanceController = new InstanceController(instanceServiceMock.Object);
            var result = instanceController.GetAllInstance() as InstanceView;
            Assert.IsNotNull(result);
        }

        [Test()]
        public void GetoneTest()
        {
            InitParamter(ins1, ins2);
            InstanceView instanceView = new InstanceView();
            instanceView.StatusCode = "66";
            Mock<IInstanceService> instanceServiceMock = new Mock<IInstanceService>();
            instanceServiceMock.Setup(f => f.GetOneInstance(ins1)).Returns(instanceView);

            InstanceController instanceController = new InstanceController(instanceServiceMock.Object);
            var result = instanceController.Getone(ins1) as InstanceView;
            Assert.IsNotNull(result);

        }

        [Test()]
        public void AddOneInstanceTest()
        {
            InitParamter(ins1, ins2);
            InstanceView instanceView = new InstanceView();
            instanceView.StatusCode = "66";
            Mock<IInstanceService> instanceServiceMock = new Mock<IInstanceService>();
            instanceServiceMock.Setup(f => f.InsertInstance(ins2)).Returns(instanceView);

            InstanceController instanceController = new InstanceController(instanceServiceMock.Object);
            var result = instanceController.AddOneInstance(ins2) as InstanceView;
            Assert.IsNotNull(result);

        }

        [Test()]
        public void DeletinstanceTest()
        {
            InitParamter(insJ);
            InitParamter(ins1, ins2);
            InstanceView instanceView = new InstanceView();
            instanceView.StatusCode = "66";
            Mock<IInstanceService> instanceServiceMock = new Mock<IInstanceService>();

            instanceServiceMock.Setup(f => f.RemoveIntance(It.IsAny<Instance>())).Returns(instanceView);

            InstanceController instanceController = new InstanceController(instanceServiceMock.Object);
            var result = instanceController.Deletinstance(insJ) as InstanceView;
            Assert.IsNotNull(result.StatusCode);
        }

        [Test()]
        public void UpdateinstanceTest()
        {
            InitParamter(insJ);
            InitParamter(ins1, ins2);

            InstanceView instanceView = new InstanceView();
            instanceView.StatusCode = "66";
            Mock<IInstanceService> instanceServiceMock = new Mock<IInstanceService>();
            instanceServiceMock.Setup(f => f.UpdateIntance(It.IsAny<Instance>())).Returns(instanceView);

            InstanceController instanceController = new InstanceController(instanceServiceMock.Object);
            var result = instanceController.Updateinstance(insJ) as InstanceView;
            Assert.IsNotNull(result);
        }
    }
}