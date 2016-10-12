using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Security;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace App.Api.Features.Security
{
    [RoutePrefix("api/permissions")]
    public class PermissionsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IResponseData<IList<PermissionListItem>> GetPermissions()
        {
            IResponseData<IList<PermissionListItem>> response = new ResponseData<IList<PermissionListItem>>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                IList<PermissionListItem> items = permissionService.GetPermissions();
                response.SetData(items);
            }
            catch (ValidationException ex)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(ex.Errors);
            }
            return response;
        }

        [Route("{itemId}")]
        [HttpDelete]
        public IResponseData<string> DeletePermissionById([FromUri] string itemId)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.DeletePermissionById(itemId);
            }
            catch (ValidationException exception)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(exception.Errors);
            }
            return response;
        }
    }
}
