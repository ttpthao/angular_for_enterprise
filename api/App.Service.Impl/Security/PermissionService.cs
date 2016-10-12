using App.Common.DI;
using App.Repository.Security;
using App.Service.Security;
using System.Collections.Generic;
using App.Entity.Security;
using App.Common.Data;
using App.Context;
using App.Common;
using System;
using App.Common.Validation;

namespace App.Service.Impl.Security
{
    internal class PermissionService : IPermissionService
    {
        public void CreateIfNotExist(IList<Permission> permissions)
        {
            if (permissions == null) { return; }
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionRepository permissionRepository = IoC.Container.Resolve<IPermissionRepository>(uow);
                foreach (Permission permission in permissions)
                {
                    Permission existPermission = permissionRepository.GetByKey(permission.Key);
                    if (existPermission != null) continue;
                    permissionRepository.Add(permission);
                }
                uow.Commit();
            }
        }

        public void DeletePermissionById(string itemId)
        {
            ValidateForDelete(itemId);
            using(IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionRepository permissionRepository = IoC.Container.Resolve<IPermissionRepository>(uow);
                permissionRepository.Delete(itemId);
                uow.Commit();
            }
        }

        private void ValidateForDelete(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new ValidationException("security.deletePermissionById.invalidId");
            }
            Guid id;
            if(!Guid.TryParse(itemId, out id))
            {
                throw new ValidationException("security.deletePermissionById.invalidId");
            }
        }

        public IList<PermissionListItem> GetPermissions()
        {
            IPermissionRepository permissionRepository = IoC.Container.Resolve<IPermissionRepository>();
            return permissionRepository.GetItems<PermissionListItem>();
        }
    }
}
