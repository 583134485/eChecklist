using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gdc.Apps.Echecklist.Models.MongoModels;
using Gdc.Apps.Echecklist.Models.ViewModels;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;

namespace Gdc.Apps.Echecklist.Providers.Implement
{
    public class StepService : IStepService
    {
        private IStepRepositories stepRepositories;
        private IWorkflowRepositories workflowRepositories;
        private IInstanceRepositories instanceRepositories;
        private const string SUCCESS = "01";
        private const string FAILTURE = "00";
        // Duplicate checking  StatusCode
        private const string REPETITION = "02";

        public StepService(IStepRepositories stepRepositories,IWorkflowRepositories workflowRepositories,IInstanceRepositories instanceRepositories)
        {
            this.stepRepositories = stepRepositories;
            this.workflowRepositories = workflowRepositories;
            this.instanceRepositories = instanceRepositories;
        }

        public StepView AddStep(Step step)
        { 
           // bool result = false;
            StepView stepView = new StepView();
         
           // workflowRepositories.GetOne(step);
            if (step.Name==null ||step.WorkflowID==null)
            {
                stepView.StatusCode = FAILTURE;
                //stepView.Data = step;
                return stepView;
            }
            else
            {
                Step searchstep = stepRepositories.GetOneStepByName(step);
                if (searchstep == null)
                {
                    bool result= stepRepositories.CreateStep(step);
                    if (result)
                    {
                        Step returnstep = stepRepositories.GetOneStepByName(step);
                        if (returnstep != null)
                        {
                            stepView.SetData(returnstep);
                            stepView.StatusCode = SUCCESS;
                            return stepView;
                        }
                    }

                    
                  //  stepView.Data = step;
                }
                else
                {
                    stepView.StatusCode = REPETITION;
                   // return stepView;
                }    
            }
            //if (result)
            //{

            //   Step finalStep = stepRepositories.GetOneStepByName(step);
            //    //Workflow workflow = new Workflow();
            //    //workflow.Id = step.WorkflowID;
            //    Workflow workFlow = workflowRepositories.GetOneById(step.WorkflowID);
            //    if (workFlow == null)
            //    {
            //        stepView.StatusCode = FAILTURE;
            //        stepView.Data = step;
            //        return stepView;
            //    }
            //    else
            //    {
            //         workFlow.StepId.Add("qqq");
            //       // list.Add("qqq");
            //        workflowRepositories.Update(workFlow);
            //        stepView.StatusCode = SUCCESS;
            //        stepView.Data = step;
            //    }
            //}
            stepView.StatusCode = FAILTURE;
            return stepView;
        }

        public StepView EditStep(Step step)
        {
            //bool result = false;
            StepView stepView = new StepView();

            if (step.Id == null || step.Name == null)
            {
                stepView.StatusCode = FAILTURE;
                return stepView;
            }
            else
            {
                Step ste = stepRepositories.GetOneStepById(step);
                if (ste == null || ste.Id == step.Id)
                {
                    stepRepositories.Update(step);
                    stepView.StatusCode = SUCCESS;
                   
                }
                else
                {
                    stepView.StatusCode = REPETITION;
                }
            }

            return stepView;
        }

        public StepView GetAllSteps()
        {
            StepView stepView = new StepView();
            List<Step> steps=stepRepositories.GetAllStep();
            stepView.StatusCode = SUCCESS;
            stepView.SetData(steps);
            return stepView;
        }

        public StepView GetOneStepById(Step step)
        {
            StepView stepview = new StepView();
            if (step.Id == null)
            {
                stepview.StatusCode = FAILTURE;
            }
            else
            {
                stepRepositories.GetOneStepById(step);
                stepview.StatusCode = SUCCESS;
                stepview.SetData(step);
            }
            //stepview = FAILTURE;
            return stepview;
        }

        public StepView RemoveStep(Step step)
        {
            //bool result = false;
            StepView stepView = new StepView();
          
            if (step.Id == null)
            {
                stepView.StatusCode = FAILTURE;
                return stepView;
            }
            else
            {
                Step ste = stepRepositories.GetOneStepById(step);
                if (ste == null)
                {
                    stepView.StatusCode = FAILTURE;
                    //return stepView;
                }
                else
                {
                     stepRepositories.Remove(step);
                    stepView.StatusCode = SUCCESS;
                      //stepView.Data = step;
                }
            }
            //if (result)
            //{
            //    stepView.StatusCode = SUCCESS;
            //    stepView.Data = step;
            //   // List<Workflow> list = 
            //    Workflow workflow = workflowRepositories.GetOneById(step.WorkflowID);
            //    if (workflow.StepId.Contains(step.Id))
            //    {
            //        workflow.StepId.Remove(step.Id);
            //        workflowRepositories.Update(workflow);
            //    }
                
            //}

            return stepView;
        }

        public ViewData<Instance> GetInstanceByStep(Step step)
        {
            ViewData<Instance> viewData = new ViewData<Instance>();
            if (step.Id == null)
            {
                viewData.StatusCode = FAILTURE;
                return viewData;
            }
            List<Instance> instances = instanceRepositories.GetSomeInstanceByStepId(step.Id);
            viewData.StatusCode = SUCCESS;
            viewData.SetData(instances);
            return viewData;
        }

        public StepView GetStepsByWorkflowId(Step step)
        {
            
            StepView stepView = new StepView();
            if (step.WorkflowID == null)
            {
                stepView.StatusCode = FAILTURE;
            }
            else
            {
                List<Step> list = new List<Step>();
                list =  stepRepositories.GetStepsByWorkflowId(step.Id);
                stepView.StatusCode = SUCCESS;
                stepView.SetData(list);
            }
            //throw new NotImplementedException();
            return stepView;
        }
    }
}
