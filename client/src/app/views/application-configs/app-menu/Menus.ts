import { MenuItem } from "./MenuItem";

export class Menus {

    public static Administrator: MenuItem[] = [
        {
            name: "Overview",
            route: "overview",
            icon: "../../../assets/icons/light/Menu/Overview.svg"
        },

        {
            name: "Internships",
            route: "internships",
            icon: "../../../assets/icons/light/Global/Internship.svg"
        },

        {
            name: "Curriculum",
            route: "curriculum",
            icon: "../../../assets/icons/light/Global/Curriculum.svg"
        },

        {
            name: "Accounts",
            route: "accounts",
            icon: "../../../assets/icons/light/Global/Trainers.svg"
        },
        {
            name: "Sandbox",
            route: "sandbox",
            icon: "../../../assets/icons/light/Global/Search.svg"
        }
    ] 

    public static InternshipSettings: MenuItem[] = [
        {
            name: "Setup",
            route: "",
            icon: "../../../assets/icons/dark/Global/Configuration.svg"
        },
        {
            name: "Mentorships",
            route: "mentorships",
            icon: "../../../assets/icons/dark/Global/Mentorships.svg"
        },
    ]

}