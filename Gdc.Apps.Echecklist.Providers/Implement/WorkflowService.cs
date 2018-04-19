using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.Apps.Echecklist.Providers.Implement
{
    public  class WorkflowService:IWorkflowService
    {
        private readonly IWorkflowRepositories workflowRepositories;
        private readonly IStepRepositories stepRepositories;
        private const string SUCCESS = "01";
        private const string FAIL = "00";

        public WorkflowService(IWorkflowRepositories workflowRepositories,IStepRepositories stepRepositories)
        {
            this.workflowRepositories = workflowRepositories;
            this.stepRepositories = stepRepositories;
        }


        public ViewData<Workflow> GetAll()
        {
            ViewData<Workflow> viewData = new ViewData<Workflow>();
            List<Workflow> workflows = workflowRepositories.GetAll();
            if (workflows != null) {
                viewData.StatusCode = SUCCESS;
                viewData.SetData(workflows);
                return viewData;
            }
            viewData.StatusCode = FAIL;
            return viewData;


        }

        //get one for both id and  name but id is first
        public ViewData<Workflow> GetOne(Workflow workflow)
        {
            ViewData<Workflow> viewdata = new ViewData<Workflow>();

            if (workflow.Id == null && workflow.Name == null)
            {
                viewdata.StatusCode = FAIL;
                return viewdata;
            }
            else if (workflow.Id != null)
            {
                Workflow result = workflowRepositories.GetOneById(workflow.Id);
                if (result != null)
                {
                    viewdata.StatusCode = SUCCESS;

                    viewdata.SetData(result);
                    return viewdata;
                }

            }
            else if (workflow.Name != null)
            {
                Workflow result = workflowRepositories.GetOne(workflow);
                if (result != null)
                {
                    viewdata.StatusCode = SUCCESS;
                    viewdata.SetData(result);
                    return viewdata;
                }
            }
            viewdata.StatusCode = FAIL;          
            return viewdata;
        }

        //search steps for workflow 
        public ViewData<Step> GetStepsByWorkflow(Workflow workflow)
        {
            ViewData<Step> viewData = new ViewData<Step>();

            if (workflow.Id != null)
            {
                Workflow result = workflowRepositories.GetOneById(workflow.Id);
                if (result != null&&result.StepId.Count>0)
                {

                    List<Step> steps = new List<Step>();
                    foreach(String stepid in result.StepId)
                    {
                        if (stepid != null)
                        {
                            Step stepinput = new Step();
                            stepinput.Id = stepid;
                            Step steptemp = stepRepositories.GetOneStepById(stepinput);
                            if (steptemp != null)
                            {
                                steps.Add(steptemp);
                            }

                        }
                    }
                    viewData.StatusCode = SUCCESS;
                    viewData.SetData(steps);
                }
            }
            viewData.StatusCode = FAIL;
            return viewData;
        }

        public ViewData<Workflow> Insert(Workflow workflow)
        {
            ViewData<Workflow> viewData = new ViewData<Workflow>();
            bool result = workflowRepositories.Insert(workflow);
            if (result) {
                Workflow reworkflow = workflowRepositories.GetOne(workflow);
                if (reworkflow != null)
                {
                    viewData.SetData(reworkflow);
                    viewData.StatusCode = SUCCESS;
                    return viewData;
                }
           
                    }
            viewData.StatusCode = FAIL;
            return viewData;
        }

        public ViewData<Workflow> Update(Workflow workflow)
        {
            ViewData<Workflow> viewData = new ViewData<Workflow>();
            if (workflow.Id == null)
            {
                viewData.StatusCode = FAIL;
                return viewData;
            }
            bool result=workflowRepositories.Update(workflow);
            if (result)
            {
                viewData.StatusCode = SUCCESS;
                return viewData;
            }
            viewData.StatusCode = FAIL;
            return viewData;
        }

        public ViewData<Workflow> Remove(Workflow workflow)
        {
            ViewData<Workflow> viewData = new ViewData<Workflow>();
            if (workflow.Id == null)
            {
                viewData.StatusCode = FAIL;
                return viewData;
            }
            bool result = workflowRepositories.Remove(workflow.Id);
            if (result)
            {
                viewData.StatusCode = SUCCESS;
                return viewData;
            }
            viewData.StatusCode = FAIL;
            return viewData;
        }

        //
        public ViewData<Step> GetStepsByWorkflowId(Workflow workflow)
        {
            ViewData<Step> viewData = new ViewData<Step>();
            if (workflow.Id == null)
            {
                viewData.StatusCode = FAIL;
                return viewData;
            }
            List<Step> steps = stepRepositories.GetStepsByWorkflowId(workflow.Id);
            viewData.StatusCode = SUCCESS;
            viewData.SetData(steps);
            return viewData;
        }
    }
}
