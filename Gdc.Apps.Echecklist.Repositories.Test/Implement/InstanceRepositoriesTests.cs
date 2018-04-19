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
    public class InstanceRepositoriesTests
    {
        [Test()]
        public void InstanceRepositoriesTest()
        {
            
        }

        [Test()]
        public void CreateInstanceTest()
        {

        }

        [Test()]
        public void CreateInstanceTemplateTest()
        {

        }

        /*[Test()]
        public void GetAllInstanceTest()
        {
            InstanceRepositories instanceRepositories = new InstanceRepositories();
            List<Instance> instances = instanceRepositories.GetAllInstance();
            Assert.IsTrue(instances.Count > 0);
        }
		*/

        [Test()]
        public void GetOneInstanceTest()
        {

        }

        [Test()]
        public void RemoveTest()
        {

        }

        [Test()]
        public void UpdateTest()
        {
            Assert.Pass();
            //InstanceRepositories instanceRepositories = new InstanceRepositories();
            //Instance instance = new Instance();
            //instance.Id = new MongoDB.Bson.ObjectId("5ac9a0ec104ccb5170e7a42a");
            //instance.Name = "testupdate";
            //instanceRepositories.Update(instance);


        }
    }
}