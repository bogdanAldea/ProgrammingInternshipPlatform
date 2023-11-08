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
            route: 'internship-hub',
            icon: '../../../assets/icons/light/Global/Internship.svg'
        },

        {
            label: 'General Curriculum',
            route: 'general-topics',
            icon: '../../../assets/icons/light/Menu/Curriculum.svg'
        },
    ]

    public static ForAdministratorMuted: ReadonlyArray<Node> = [
        {
            label: 'Overview',
            route: 'dashboard',
            icon: '../../../assets/icons/dark/Menu/Overview.svg'
        },

        {
            label: 'Internship Hub',
            route: 'internship-hub',
            icon: '../../../assets/icons/dark/Global/Internship.svg'
        },

        {
            label: 'General Curriculum',
            route: 'general-topics',
            icon: '../../../assets/icons/dark/Menu/Curriculum.svg'
        },
    ]
}

export class InternshipOptionsNodes {
    public static ForAdministrator: ReadonlyArray<Node> = [
        {
            label: 'Configuration',
            route: 'configurations',
            icon: '../../../assets/icons/dark/Global/Configuration.svg'
        },

        {
            label: 'Curriculum',
            route: 'curriculum',
            icon: '../../../assets/icons/dark/Global/Curriculum.svg'
        },

        {
            label: 'Trainers',
            route: '',
            icon: '../../../assets/icons/dark/Global/Trainers.svg'
        },

        {
            label: 'Interns',
            route: '',
            icon: '../../../assets/icons/dark/Global/Internship.svg'
        },

        {
            label: 'Mentorships',
            route: '',
            icon: '../../../assets/icons/dark/Global/Mentorships.svg'
        }
    ]
}