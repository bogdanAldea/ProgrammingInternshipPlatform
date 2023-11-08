import { NodeData } from "../../components/navigations/node/types/nodeData";

export class MenuNodes {

    public static ForAdministrator: NodeData[] = [
        {
            label: 'Overview',
            route: 'dashboard',
            icon: '../../../../assets/icons/light/Menu/Overview.svg'
        },

        {
            label: 'Internship Hub',
            route: 'internships',
            icon: 'assets/icons/light/Global/Internship.svg'
        },

        {
            label: 'General Curriculum',
            route: 'general-curriculum',
            icon: 'assets/icons/light/Menu/Curriculum.svg'
        },
        
    ]

    public static ForSelectedInternship: NodeData[] = [
        {
            label: 'Setup',
            route: 'setup',
            icon: 'assets/icons/dark/Global/Configuration.svg'
        },
        {
            label: 'Trainers',
            route: 'trainers',
            icon: 'assets/icons/dark/Global/Configuration.svg'
        },
        {
            label: 'Mentorships',
            route: 'mentorships',
            icon: 'assets/icons/dark/Global/Mentorships.svg'
        },
    ]

    public static ForSelectedChapter: NodeData[] = [
        {
            label: 'Lessons',
            route: 'lessons',
            icon: '../../../../assets/icons/dark/Global/Mentorships.svg'
        },
        {
            label: 'Versions',
            route: 'versions',
            icon: '../../../../assets/icons/dark/Global/Configuration.svg'
        }
    ]
}