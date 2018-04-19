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

namespace Gdc.Apps.Echecklist.Providers.Test.Implement
{
    [TestFixture()]
    class StepTest
    {/*
        [Test()]
        public void addStepTest()
        {
            Step step = new Step();
            step.Name = "dmjn";
            Step step2 = new Step();
            step2 = null;
            step.WorkflowID = "11111111";
            Workflow workflow = new Workflow();
            workflow.Id = "11111111";
            Mock<IStepRepositories> StepDaoMock = new Mock<IStepRepositories>();
            Mock<IWorkflowRepositories> workflowDaoMock = new Mock<IWorkflowRepositories>();
            StepDaoMock.Setup(f => f.CreateStep(step)).Returns(true);
            workflowDaoMock.Setup(x => x.GetOneById(step.WorkflowID)).Returns(workflow);
            StepDaoMock.Setup(f => f.GetOneStepByName(step)).Returns(step2);
           // StepService service = new StepService(StepDaoMock.Object, workflowDaoMock.Object);
          // StepView stepview =  service.AddStep(step);
            // TemplateService impl = new StepDaoMock(StepDaoMock.Object);

            //Assert.Pass();
        }*/
    }
}
