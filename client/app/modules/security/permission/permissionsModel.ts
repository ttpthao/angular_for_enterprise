export class PermissionsModel {
    public eventKey: string = "permissions_onDataLoaded";
    public options: any;
    constructor(i18n: any) {
        let self = this;
        self.options = {
            data: [],
            columns: [
                { field: "name", title: i18n.security.permissions.grid.name, index: 0 },
                { field: "key", title: i18n.security.permissions.grid.key, index: 1 },
                { field: "description", title: i18n.security.permissions.grid.description, index: 2 }
            ],
            enableDelete: true
        };
    };

    public import(items: Array<any>) {
        let eventManager = window.ioc.resolve("IEventManager");
        eventManager.publish(this.eventKey, items);
    }
}