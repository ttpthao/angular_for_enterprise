import configHelper from "../../../../common/helpers/configHelper";
let permissionService = {
    loadPermissions: loadPermissions,
    delete: remove
};
export default permissionService;
function loadPermissions() {
    let url = String.format("{0}/permissions", configHelper.getAppConfig().api.baseUrl);
    let connector = window.ioc.resolve("IConnector");
    return connector.get(url);
}

function remove(id: any){
    let url = String.format("{0}/permissions/{1}", configHelper.getAppConfig().api.baseUrl, id);
    let connector = window.ioc.resolve("IConnector");
    return connector.delete(url);
}