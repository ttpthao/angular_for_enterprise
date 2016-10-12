using System.Collections.Generic;
using App.Entity.Security;

namespace App.Service.Security
{
    public interface IPermissionService
    {
        IList<PermissionListItem> GetPermissions();
        void CreateIfNotExist(IList<Permission> permissions);
        void DeletePermissionById(string itemId);
    }
}
