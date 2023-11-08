import { RouteNode } from "./node";

export class ApplicationRouteNodes {

    public static Administrator: ReadonlyArray<RouteNode> = [
        {
            label: 'Overview',
            icon: 'assets/icons/dark/Overview.svg',
            activeIcon: 'assets/icons/light/Overview.svg',
            route: 'overview'
        },
        {
            label: 'Internship Hub',
            icon: 'assets/icons/dark/Internship.svg',
            activeIcon: 'assets/icons/light/Internship.svg',
            route: 'internship-hub'
        },
        {
            label: 'Curriculum',
            icon: 'assets/icons/dark/Curriculum.svg',
            activeIcon: 'assets/icons/light/Curriculum.svg',
            route: 'curriculum'
        }
    ];

    public static Coordinator: ReadonlyArray<RouteNode> = [];

    public static Trainer: ReadonlyArray<RouteNode> = [];

    public static Intern: ReadonlyArray<RouteNode> = [];
}

export class InternshipOptionsRouteNodes {

    public static Administrator: ReadonlyArray<RouteNode> = [
        {
            label: 'Configurations',
            route: 'configurations',
        },

        {
            label: 'Curriculum',
            route: 'curriculum',
        },

        {
            label: 'Interns',
            route: 'interns',
        },

        {
            label: 'Trainers',
            route: 'trainers',
        },

        {
            label: 'Mentorships',
            route: 'mentorships',
        }
    ]

}