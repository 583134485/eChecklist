namespace WebApi.EChecklist.Providers.InterfaceImplement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Models.ViewModels;
    using WebApi.EChecklist.Providers.Interface;
    using WebApi.EChecklist.Repositories.Interface;

    public class InstanceServiceImp : IInstanceService
    {
        private IInstanceDao instancedao;
        private const string SUCCESS = "01";
        private const string FAILTURE = "00";


        // public InstanceServiceImp()
        // {
        //    instancedao = new InstanceDaoImpl();
        // }
        public InstanceServiceImp(IInstanceDao instanceDao)
        {
            this.instancedao = instanceDao;
        }

        public InstanceView GetAllInstance()
        {
            InstanceView instanceView = new InstanceView();
            List<Instance> ins = this.instancedao.GetAllInstance();
            instanceView.Data = ins;
            instanceView.StatusCode = SUCCESS;
            return instanceView;
        }

        public InstanceView GetOneInstance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            Instance ins = this.instancedao.GetOneInstance(instance.Name, instance.Type);
            if (string.IsNullOrEmpty(ins.Name))
            {
                instanceView.StatusCode = FAILTURE;
            }
            else
            {
                instanceView.StatusCode = SUCCESS;
                List<Instance> instancedata = new List<Instance>();
                instancedata.Add(ins);
                instanceView.Data = instancedata;
            }

            return instanceView;
        }

        public InstanceView InsertInstance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            /*   InstanceView ins = GetOneInstance(instance);
           if (SUCCESS.Equals(ins.statusCode))
           {
               instanceView.statusCode = FAILTURE;
           }
           else
           {
               instancedao.CreateInstance(instance);
               instanceView.statusCode = SUCCESS;
               instanceView.instance.Add(instance);
           }
           */

            bool result = this.instancedao.CreateInstance(instance);

            // Console.Write();
            if (result)
            {
                instanceView.StatusCode = SUCCESS;
                Instance ins = this.instancedao.GetOneInstance(instance.Name, instance.Type);
                List<Instance> instances = new List<Instance>();
                instances.Add(ins);
                instanceView.Data = instances;
            }
            else
            {
                instanceView.StatusCode = FAILTURE;
            }

            return instanceView;
        }

        public InstanceView RemoveIntance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            this.instancedao.Remove(instance.Name);
            List<Instance> instances = new List<Instance>();
            instances.Add(instance);
            instanceView.Data = instances;
            instanceView.StatusCode = SUCCESS;
            return instanceView;
        }

        public InstanceView UpdateIntance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            this.instancedao.Update(instance.Name, instance);
            List<Instance> instances = new List<Instance>();
            instances.Add(instance);
            instanceView.Data = instances;
            instanceView.StatusCode = SUCCESS;
            return instanceView;
        }
    }
}
