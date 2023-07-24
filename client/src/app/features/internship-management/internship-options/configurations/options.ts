import { Option } from "./option";

export namespace Options 
{
    export class Configurations 
    {
        public static icon: string = './../../assets/icons/internship-options/settings.svg';
        public static title: string = 'Configurations';
        public static description: string = 'Configure internship parameters.';
        public static options: Option[] = 
        [
            {
                name: 'Settings',
                description: `Set up the internship parameters and ensure a smooth a
                dministrative process throughout the program.`,
                route: '',
            },

            {

                name: 'Curriculum',
                description: `Ensure a structured and progressive learning journey for the interns, 
                            covering all relevant topics and skill sets.`,
                route: ''
                }
        ]
    }

    export class Members 
    {
        public static icon: string = './../../assets/icons/internship-options/interns.svg';
        public static title: string = 'Members';
        public static description: string = 'Manage interns and trainers.';
        public static options: Option[] = 
        [
            {
                name: 'Interns',
                description: `Manage intern-related information efficiently, track their progress, and update their details as required.`,
                route: ''
            },
    
            {
                name: 'Trainers',
                description: `Monitor the trainers' involvement, assign responsibilities, and keep track of their 
                            contributions to the interns' development.`,
                route: ""
            },
        ]
    }

    export class Collaboration
    {
        public static icon: string = './../../assets/icons/internship-options/mentorship.svg';
        public static title: string = 'Collaboration';
        public static description: string = 'Facilitate mentorship relationships.';
        public static options: Option[] = 
        [
            {
                name: 'Mentorships',
                description: `Foster a supportive environment, enhance the overall learning experience and ensure effective guidance for the interns.`,
                route: ""
            },
        ]
    }
}