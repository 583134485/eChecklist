using NUnit.Framework;
using Gdc.Apps.Echecklist.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;

namespace Gdc.Apps.Echecklist.Repositories.Implement.Tests
{
    [TestFixture()]
    public class WorkflowRepositoriesTests
    {
        Workflow publicworkflow = new Workflow();
        private void copydata(Workflow workflow)
        {
            publicworkflow.Name = workflow.Name;
            publicworkflow.Id = workflow.Id;
            Console.Write("copy workflow  name and in =" + publicworkflow.Name + publicworkflow.Id);
        }

        [Test()]
        public void WorkflowRepositoriesTest()
        {

        }

        [Test()]
        public void InsertTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            Workflow workflow = new Workflow();
            workflow.Name = "test";
            workflow.Modifiedtime = DateTime.Now;
            bool result = workflowRepositories.Insert(workflow);
            if (result) { copydata(workflow); }
            Assert.AreEqual(true, result);
        }

        [Test()]
        public void GetAllTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            List<Workflow> workflow = workflowRepositories.GetAll();
            foreach (Workflow a in workflow)
            {
                Console.Write("name:"+a.Name+"--id:"+a.Id+"--time:"+a.Modifiedtime);
            }
            Assert.Pass();
        }

        [Test()]
        public void GetOneTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            Workflow workflow = new Workflow();
            workflow.Name = "test";
            Workflow result = workflowRepositories.GetOne(workflow);
            Console.Write(result.Name + result.Id);
            if (result != null) { copydata(result); }
            Assert.IsNotNull(result);

        }
        [Test()]
        public void GetOneByIdTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            Workflow workflow = new Workflow();
            workflow.Id = publicworkflow.Id;
            Console.Write("public id="+workflow.Id);
            Workflow result = workflowRepositories.GetOneById("5ad6e0dd104ccd3e10a4f198");
            Console.Write(result.Name+"////" + result.Id);
            Assert.IsNotNull(result);
        }


        [Test()]
        public void UpdateTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            Workflow workflow = new Workflow();
            workflow.Id = publicworkflow.Id;
            workflow.Name = "update test";
            bool result = workflowRepositories.Update(workflow);
        }

        [Test()]
        public void RemoveTest()
        {
            WorkflowRepositories workflowRepositories = new WorkflowRepositories();
            Workflow workflow = new Workflow();
            workflow.Id = publicworkflow.Id;
            bool result = workflowRepositories.Remove(workflow.Id);
            Assert.AreEqual(true, result);
        }


    }
}