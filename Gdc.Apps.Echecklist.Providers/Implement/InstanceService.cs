using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Implement
{
    public class InstanceService:IInstanceService
    {
        private IInstanceRepositories instanceRepositories;
        private ITemplateRepositories templateRepositories;
        private const string SUCCESS = "01";
        private const string FAILTURE = "99";
        // Duplicate checking  StatusCode
        private const string REPETITION = "02";

        public InstanceService(IInstanceRepositories instanceRepositories, ITemplateRepositories templateRepositories)
        {
            this.instanceRepositories = instanceRepositories;
            this.templateRepositories = templateRepositories;
        }

        public InstanceView GetAllInstance()
        {
            InstanceView instanceView = new InstanceView();
            List<Instance> ins = this.instanceRepositories.GetAllInstance();
            instanceView.Data = ins;
            instanceView.StatusCode = SUCCESS;
            return instanceView;
        }

        public InstanceView GetOneInstance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            Instance ins = this.instanceRepositories.GetOneInstance(instance.Name, instance.Type);
            if (ins==null)
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
            bool result = false;
            Template template = null;
            template = this.templateRepositories.GetOneTemplate(instance.Template, instance.Type);
            if (template == null || String.IsNullOrEmpty(template.Name))
            {
                result = false;
            }
            else
            {
           
                Instance ins = this.instanceRepositories.GetOneInstance(instance.Name, template.Type);
                if (ins==null)
                {
                    result = true;
                    Instance instancedata = new Instance();
                    instancedata.Name = instance.Name;
                    instancedata.Template = template.Name;
                    instancedata.Type = template.Type;
             
                    result = this.instanceRepositories.CreateInstance(instancedata);

                }
                else
                {
                    result = false;
                    instanceView.StatusCode = REPETITION;
                    return instanceView;
                }
            }

            if (result)
            {
                instanceView.StatusCode = SUCCESS;
                Instance ins = this.instanceRepositories.GetOneInstance(instance.Name, instance.Type);
                List<Instance> instances = new List<Instance>();
                instances.Add(ins);
                instanceView.Data = instances;
                return instanceView;
            }
            else
            {

                instanceView.StatusCode = FAILTURE;
            }

            return instanceView;
        }

        public InstanceView RemoveIntance(Instance instance)
        {
            bool result = false;
            InstanceView instanceView = new InstanceView();
            result=this.instanceRepositories.Remove(instance.Id);

            if (result == false)
            {
                instanceView.StatusCode = FAILTURE;
            }
            else
            {
                List<Instance> instances = new List<Instance>();
                instances.Add(instance);
                instanceView.Data = instances;
                instanceView.StatusCode = SUCCESS;
            }

            return instanceView;
        }

        public InstanceView UpdateIntance(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            bool result = false;

                //find template first 
                Template template = templateRepositories.GetOneTemplate(instance.Template,string.Empty);
				 Instance ins = this.instanceRepositories.GetOneInstance(instance.Name, instance.Type);
                if (template == null)
                {
                    result = false;                 
                }
                else
                {                  
                     if (ins == null || ins.Id == instance.Id)
                {
                   Debug.WriteLine(ins);
                    instance.Template = template.Name;
                    instance.Type = template.Type;
                    result = instanceRepositories.Update(instance);
                    Debug.Write("insertfail null");
                }
                else
                {
                    instanceView.StatusCode = REPETITION;
                    List<Instance> instances = new List<Instance>();
                    instances.Add(instance);
                    instanceView.Data = instances;
                    return instanceView;
                }
                }
           

            if (result)
            {
                List<Instance> instances = new List<Instance>();
                instances.Add(instance);
                instanceView.Data = instances;
                instanceView.StatusCode = SUCCESS;    
            }
            else
            {
                instanceView.StatusCode = FAILTURE;
            }
            return instanceView;
        }

        public InstanceView InsertBatchInsert(Instance instance)
        {
            //Instance insertdata = new Instance();
            //insertdata.Template = "test100";
            //insertdata.Name = "test100";
            //List<Instance> listdata = new List<Instance>();
            //for (int i = 1; i < 10; i++)
            //{
            //    listdata.Add(insertdata);
            //}
            //bool result = instanceRepositories.InsertBarch(listdata);
            //InstanceView instanceView = new InstanceView();
            //instanceView.StatusCode = result.ToString();
            //return instanceView;
            return null;
        }

        //for add instance for step
        //stepid is needed
        //暂时不加 查询 stepid 是否存在的情况
        public InstanceView InsertInstanceForStep(Instance instance)
        {
            InstanceView instanceView = new InstanceView();
            bool result = false;
           // Template tem = new Template();
           // tem = instance.Template;
            if (instance.stepid == null || instance.Name ==null)
            {
                instanceView.StatusCode = FAILTURE;
                return instanceView;
            }
            Instance ins = instanceRepositories.GetOneInstance(instance.Name, instance.Type);
            if(ins == null)
            {
               result = true;
               result =  instanceRepositories.CreateInstance(instance);
                return null;
            }
            else
            {
                instanceView.StatusCode = REPETITION;
                return instanceView;
            }
            if (result)
            {
                Instance ins_final = instanceRepositories.GetOneInstance(instance.Name, instance.Type);
                List<Instance> list = new List<Instance>();
                list.Add(ins_final);
                instanceView.StatusCode = SUCCESS;
                instanceView.Data = list;
                return instanceView;
            }
            instanceView.StatusCode = FAILTURE;
            return instanceView;

        }
    }
}
