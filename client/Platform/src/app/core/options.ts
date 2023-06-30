import { Option } from "./option";

export class Options {

    public static InternshipOtions: Option[] = 
    [
        {
            icon: "../../../assets/icons/internship-options/settings.svg",
            name: "Settings",
            description: `The Settings page provides you with essential details about the selected internship.
                         Here, you can configure and manage various aspects such as the start date, end date, 
                         location, number of interns, and coordinator. This information allows you to set up the 
                         internship parameters and ensure a smooth administrative process throughout the program.`,
            route: "settings"
        },

        {
            icon: "./../../assets/icons/internship-options/interns.svg",
            name: "Interns",
            description: `The Interns page offers a comprehensive overview of all the interns participating in the 
                        internship program. You can access a list of interns and perform CRUD (Create, Read, Update, Delete) 
                        operations on individual intern profiles. This functionality enables you to manage intern-related 
                        information efficiently, track their progress, and update their details as required.`,
            route: "interns"
        },

        {
            icon: "./../../assets/icons/internship-options/trainers.svg",
            name: "Trainers",
            description: `The Trainers page allows you to view and manage the trainers involved in the internship program. 
                        You can access a list of trainers and utilize CRUD operations to handle their profiles. This feature 
                        helps you monitor the trainers' involvement, assign responsibilities, and keep track of their 
                        contributions to the interns' development.`,
            route: "trainers"
        },

        {
            icon: "./../../assets/icons/internship-options/mentorship.svg",
            name: "Mentorships",
            description: `The Mentorships page provides a platform to oversee and facilitate mentorship relationships within 
                        the internship program. It allows you to create and manage mentor-mentee pairs, view the progress of 
                        mentorship activities, and ensure effective guidance for the interns. This feature empowers you to 
                        foster a supportive environment and enhance the overall learning experience.`,
            route: "mentorships"
        },

        {
            icon: "./../../assets/icons/internship-options/curriculum.svg",
            name: "Curriculum",
            description: `The Modules page offers a centralized hub for managing the various modules or learning components of 
                        the internship program. You can organize and structure the curriculum, track the completion status of 
                        each module, and update content as needed. This functionality allows you to ensure a structured and 
                        progressive learning journey for the interns, covering all relevant topics and skill sets.`,
            route: "curriculum"
        }
    ]
}
