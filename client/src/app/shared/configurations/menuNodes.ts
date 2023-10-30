import { Node } from "../components/navigations/link-node/link-node.component";

export class MenuNodes {
    public static ForAdministrator: ReadonlyArray<Node> = [
        {
            label: 'Overview',
            route: 'dashboard',
            icon: '../../../assets/icons/light/Menu/Overview.svg'
        },

        {
            label: 'Internship Hub',
            route: 'internships',
            icon: '../../../assets/icons/light/Global/Internship.svg'
        },

        {
            label: 'General Curriculum',
            route: 'general-topics',
            icon: '../../../assets/icons/light/Menu/Curriculum.svg'
        },
    ]
}