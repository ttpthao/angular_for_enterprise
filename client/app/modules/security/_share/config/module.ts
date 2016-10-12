import { IModule, Module, MenuItem } from "../../../../common/models/layout";
import routeConfig from "./routeConfig";
import { Permissions } from "./../../permission/permissions";
import { AuthenticationMode } from "../../../../common/enum";
let security: IModule = createModule();
export default security;
function createModule() {
    let module = new Module("app/modules/security", "security");
    module.menus.push(
        new MenuItem("Security", routeConfig.permissions.name, "fa fa-edit",
            new MenuItem(routeConfig.permissions.name, routeConfig.permissions.name, "")
        )
    );
    module.addRoutes([
        {
            path: routeConfig.permissions.path,
            name: routeConfig.permissions.name,
            component: Permissions,
            data: { Authentication: AuthenticationMode.Require }
        }
    ]);
    return module;
}