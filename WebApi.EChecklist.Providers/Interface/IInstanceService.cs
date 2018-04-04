// <copyright file="InstanceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace WebApi.EChecklist.Providers.Interface
{
    using WebApi.EChecklist.Models.MongoModels;
    using WebApi.EChecklist.Models.ViewModels;

    public interface IInstanceService
    {
        InstanceView GetAllInstance();

        InstanceView GetOneInstance(Instance instance);

        InstanceView InsertInstance(Instance instance);

        // addtemplate and  updateinstance  in this method
        InstanceView UpdateIntance(Instance instance);

        InstanceView RemoveIntance(Instance instance);
    }
}
