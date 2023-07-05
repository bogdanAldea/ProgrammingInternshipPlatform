export class MenuItem {

    public route: string;
    public name: string;
    public icon: string;

    constructor(route: string, name: string, icon: string) {
        this.route = route;
        this.name = name;
        this.icon = icon;
    }
}