import { Component } from "angular2/core";
import { Grid } from "../../../common/directive";
import { BasePage } from "../../../common/models/ui";
import { PermissionsModel } from "./permissionsModel";
import permissionService from "../_share/services/permissionService";
@Component({
    templateUrl: "app/modules/security/permission/permissions.html",
    directives: [Grid]
})
export class Permissions extends BasePage {
    public model: PermissionsModel;
    constructor() {
        super();
        let self: Permissions = this;
        self.model = new PermissionsModel(self.i18n);
        self.loadPermissions();
    };

    public loadPermissions() {
        let self: Permissions = this;
        permissionService.getPermissions().then((perItems: Array<any>) => {
            self.model.import(perItems);
        });
    }

    public onPermissionDeleteClicked(perItem: any) {
        let self: Permissions = this;
        permissionService.deletePermissionById(perItem.item.id).then(() => {
            self.loadPermissions();
        });
    }
}