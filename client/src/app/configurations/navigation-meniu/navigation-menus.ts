import { MenuItem} from './menu-item';

export class Menus {

    public static administratorMenuItems: MenuItem[] = 
    [
        {
            name: "Overview",
            route: "overview",
            icon: "../../../assets/icons/menus/admin/overview.svg"
        },
        {
            name: "Internships",
            route: "internships",
            icon: "../../../assets/icons/menus/admin/internship.svg"
        },
        {
            name: "Curriculum",
            route: "curriculum",
            icon: "../../../assets/icons/menus/admin/list.svg"
        },
        {
            name: "Accounts",
            route: "accounts",
            icon: "../../../assets/icons/menus/admin/acounts.svg"
        },
        {
            name: "Organisation",
            route: "organisation",
            icon: "../../../assets/icons/menus/admin/organisation.svg"
        }
    ]

}