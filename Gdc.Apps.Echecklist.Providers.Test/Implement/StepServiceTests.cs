﻿using NUnit.Framework;
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
    public class StepServiceTests
    {
        Mock<IStepRepositories> StepDaoMock = new Mock<IStepRepositories>();
        Mock<IWorkflowRepositories> WorkflowDaoMock = new Mock<IWorkflowRepositories>();
        Mock<IInstanceRepositories> InstanceDaoMock = new Mock<IInstanceRepositories>();

        private const string SUCCESS = "01";
        private const string FAILTURE = "00";
        // Duplicate checking  StatusCode
        private const string REPETITION = "02";

        StepView stepView = new StepView();
        List<Step> steps = new List<Step>();
        Step step1 = new Step();
        Step step2 = new Step();
        Step step3 = new Step();
        Step step4 = new Step();

        public void InitData()
        {
            step1.Id = "0001";
            step1.Name = "step1";
            step1.Type = null;
            step1.WorkflowID = "0001";
            step1.InstanceId = null;

            step2.Id = "0002";
            step2.Name = "step2";
            step2.Type = null;
            step2.WorkflowID = "0002";
            step2.InstanceId = null;

            step3 = null;

            step4.Id = null;
            step4.Name = null;
            step4.Type = null;
            step4.WorkflowID = null;
            step4.InstanceId = null;

            steps.Clear();
        }


        [Test()]
        public void StepServiceTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void AddStepTest()
        {
            InitData();

            StepDaoMock.Setup(f => f.GetOneStepByNameAndWorkflowId(step1)).Returns(step1);
            // StepDaoMock.Setup(f => f.GetOneStepByName(step2)).Returns(step3);
            // StepDaoMock.Setup(f => f.GetOneStepByNameAndWorkflowId(step1)).
            //StepDaoMock.
            StepDaoMock.Setup(f => f.CreateStep(step2)).Returns(true);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            //
            stepView = impl.AddStep(step4);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.AddStep(step1);
            Assert.AreEqual(REPETITION, stepView.StatusCode);

            //stepView = impl.AddStep(step2);
            //Assert.AreEqual(SUCCESS, stepView.StatusCode);
        }

        [Test()]
        public void EditStepTest()
        {
            InitData();

            StepDaoMock.Setup(f => f.GetOneStepById(step1)).Returns(step2);
            StepDaoMock.Setup(f => f.GetOneStepById(step2)).Returns(step3);
            StepDaoMock.Setup(f => f.Update(step2)).Returns(true);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            stepView = impl.EditStep(step4);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.EditStep(step1);
            Assert.AreEqual(REPETITION, stepView.StatusCode);

            stepView = impl.EditStep(step2);
            Assert.AreEqual(SUCCESS, stepView.StatusCode);
        }

        [Test()]
        public void GetAllStepsTest()
        {
            InitData();
            steps.Add(step1);

            StepDaoMock.Setup(f => f.GetAllStep()).Returns(steps);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            stepView = impl.GetAllSteps();

            Assert.AreEqual(1, stepView.GetData().Count);
            Assert.AreEqual(SUCCESS, stepView.StatusCode);

        }

        [Test()]
        public void GetOneStepByIdTest()
        {
            InitData();

            StepDaoMock.Setup(f => f.GetOneStepById(step1)).Returns(step1);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            stepView = impl.GetOneStepById(step4);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.GetOneStepById(step1);
            foreach (Step step in stepView.GetData())
            {
                Assert.AreEqual(step.Id, step1.Id);
            }

            Assert.AreEqual(SUCCESS, stepView.StatusCode);
        }

        [Test()]
        public void RemoveStepTest()
        {
            InitData();
            StepDaoMock.Setup(f => f.GetOneStepById(step1)).Returns(step1);
            StepDaoMock.Setup(f => f.GetOneStepById(step2)).Returns(step3);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            stepView = impl.RemoveStep(step4);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.RemoveStep(step2);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.RemoveStep(step1);
            Assert.AreEqual(SUCCESS, stepView.StatusCode);

        }

        [Test()]
        public void GetInstanceByStepTest()
        {
            Assert.Pass();
        }

        [Test()]
        public void GetStepsByWorkflowIdTest()
        {
            InitData();
            steps.Add(step1);
            StepDaoMock.Setup(f => f.GetStepsByWorkflowId(step1.Id)).Returns(steps);

            StepService impl = new StepService(StepDaoMock.Object, WorkflowDaoMock.Object, InstanceDaoMock.Object);

            stepView = impl.GetStepsByWorkflowId(step4);
            Assert.AreEqual(FAILTURE, stepView.StatusCode);

            stepView = impl.GetStepsByWorkflowId(step1);
            foreach (Step step in stepView.GetData())
            {
                Assert.AreEqual(step.Id, step1.Id);
            }

            Assert.AreEqual(SUCCESS, stepView.StatusCode);
        }
    }
}