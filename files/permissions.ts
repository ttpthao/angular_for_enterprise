import {Component} from "angular2/core";
import {PageActions, Grid} from "../../../common/directive";
import {PermissionsModel} from "./permissionsModel";
import {BasePage} from "../../../common/models/ui";
import permissionService from "../_share/services/permissionService";
@Component({
    templateUrl: "app/modules/security/permission/permissions.html",
    directives: [PageActions, Grid]
})
export class Permissions extends BasePage {
    public model: PermissionsModel;
    constructor(i18n: any) {
        super();
        let self: Permissions = this;
        self.i18nHelper = self.i18n;
        self.model = new PermissionsModel(self.i18n);
        this.loadPermissions();
    }

    public loadPermissions() {
        let self: Permissions = this;
        permissionService.loadPermissions().then(function (perItems: Array<any>) {
            self.model.import(perItems);
        })
    }

    public onPermissionDeleteClicked(perItem: any){
        let self: Permissions = this;
        permissionService.delete(perItem.item.id).then(function(){
            self.loadPermissions();
        });
    }
}