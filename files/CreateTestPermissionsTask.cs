using App.Common.DI;
using App.Common.Tasks;
using App.Entity.Security;
using App.Service.Security;
using System.Collections.Generic;
using System.Web;

namespace App.Api.Features.Share.Tasks.Data
{
    public class CreateTestPermissionsTask : BaseTask<TaskArgument<HttpApplication>>, IApplicationReadyTask<TaskArgument<HttpApplication>>
    {
        public CreateTestPermissionsTask() : base(App.Common.ApplicationType.All)
        {
            this.Order = 2;
        }

        public override void Execute(TaskArgument<HttpApplication> context)
        {
            IList<Permission> permissions = new List<Permission>();
            permissions.Add(new Permission("Name 1", "Key 1", "Description 1"));
            permissions.Add(new Permission("Name 2", "Key 2", "Description 2"));
            permissions.Add(new Permission("Name 3", "Key 3", "Description 3"));
            permissions.Add(new Permission("Name 4", "Key 4", "Description 4"));
            IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
            permissionService.CreateIfNotExist(permissions);
        }
    }
}