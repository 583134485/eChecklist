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
    public class WorkflowServiceTests
    {
        Mock<IStepRepositories> StepDaoMock = new Mock<IStepRepositories>();
        Mock<IWorkflowRepositories> WorkflowDaoMock = new Mock<IWorkflowRepositories>();

        private const string SUCCESS = "01";
        private const string FAIL = "00";

        Workflow flow1 = new Workflow();
        Workflow flow2 = new Workflow();
        Workflow flow3 = new Workflow();
        Workflow flow4 = new Workflow();
        Workflow flow5 = new Workflow();
        Workflow flow6 = new Workflow();

        ViewData<Workflow> viewData = new ViewData<Workflow>();
        List<Workflow> workflows = new List<Workflow>();
        List<Workflow> _workflows = new List<Workflow>();
        DateTime now = DateTime.Now;

        public void initData()
        {
            flow1.Id = "fl";
            flow1.Type = "f1";
            flow1.Name = "f1";
            flow1.Modifiedtime = now;

            flow2.Id = "f2";
            flow2.Type = "f2";
            flow2.Name = "f2";
            flow2.Modifiedtime = now;

            flow3.Id = null;
            flow3.Type = null;
            flow3.Name = null;
            flow3.Modifiedtime = now;

            flow4 = null;

            flow5.Id = "f5";
            flow5.Name = null;

            flow6.Id = "f6";
            flow6.Name = null;


            workflows.Clear();
            _workflows.Clear();
        }


        [Test()]
        public void WorkflowServiceTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void GetAllWorkflowTest()
        {
            initData();
            List<Workflow> workflow = new List<Workflow>();
            workflow = null;
            _workflows.Add(flow1);

            WorkflowDaoMock.Setup(f => f.GetAll()).Returns(workflow);

            WorkflowService impl = new WorkflowService(WorkflowDaoMock.Object,StepDaoMock.Object);

            viewData = impl.GetAllWorkflow();
            Assert.AreEqual(FAIL,viewData.StatusCode);


            WorkflowDaoMock.Setup(f => f.GetAll()).Returns(_workflows);

            WorkflowService _impl = new WorkflowService(WorkflowDaoMock.Object, StepDaoMock.Object);

            viewData = _impl.GetAllWorkflow();
            Assert.AreEqual(SUCCESS, viewData.StatusCode);
            Assert.AreEqual(1, viewData.GetData().Count);
        }

        [Test()]
        public void GetOneWorkflowTest()
        {
            initData();
            flow1.Id = null;
            flow2.Id = null;

            WorkflowDaoMock.Setup(f => f.GetOneByName(flow1.Name)).Returns(flow4);
            WorkflowDaoMock.Setup(f => f.GetOneByName(flow2.Name)).Returns(flow2);
            WorkflowDaoMock.Setup(f => f.GetOneById(flow5.Id)).Returns(flow4);
            WorkflowDaoMock.Setup(f => f.GetOneById(flow6.Id)).Returns(flow6);


            WorkflowService impl = new WorkflowService(WorkflowDaoMock.Object, StepDaoMock.Object);

            viewData = impl.GetOneWorkflow(flow3);
            Assert.AreEqual(FAIL, viewData.StatusCode);

            viewData = impl.GetOneWorkflow(flow1);
            Assert.AreEqual(FAIL, viewData.StatusCode);

            viewData = impl.GetOneWorkflow(flow2);
            Assert.AreEqual(SUCCESS, viewData.StatusCode);

            viewData = impl.GetOneWorkflow(flow5);
            Assert.AreEqual(FAIL, viewData.StatusCode);

            viewData = impl.GetOneWorkflow(flow6);
            Assert.AreEqual(SUCCESS, viewData.StatusCode);

        }

        [Test()]
        public void InsertWorkflowTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void UpdateWorkflowTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void RemoveWorkflowTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void GetStepsByWorkflowTest()
        {

            Assert.Pass();
        }
    }
}