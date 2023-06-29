export class Option {
    public icon: string;
    public name: string;
    public description: string;
    public route: string;

    constructor(icon: string, name: string, description: string, route: string) {
        this.icon = icon;
        this.name = name;
        this.description = description;
        this.route = route;
    }
}
