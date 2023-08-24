import { name } from 'msal/lib-commonjs/packageMetadata';

export namespace IconRegistrar {

    const iconsPath = '../../../../assets/icons'
    const dark = `${iconsPath}/dark`
    const light = `${iconsPath}/light`
    const brand = `${iconsPath}/purple`
    const muted = `${iconsPath}/muted`;

    export class  Presentation {
        public static Dark = `${dark}/Menu/Presentations.svg`
        public static Muted = `${muted}/Menu/Presentations.svg`
        public static Light = ''
        public static Brand = ''
    }

    export class Location {
        public static Dark = `${dark}/Global/Location.svg`;
        public static Muted = `${muted}/Global/Location.svg`
        public static Light = '';
        public static Brand = '';
    }

    export class Users {
        public static Dark = `${dark}/Global/Users.svg`;
        public static Muted = `${muted}/Global/Users.svg`
        public static Light = '';
        public static Brand = '';
    }

    export class Add {
        public static Dark = `${dark}/Actions/Add.svg`;
        public static Muted = `${muted}/Actions/Add.svg`
        public static Light = '';
        public static Brand = `${brand}/Actions/Add.svg`;
    }

    export class Interns {
        public static Dark = `${dark}/Global/Internship.svg`;
        public static Muted = `${muted}/Global/Internship.svg`;
        public static Light = '';
        public static Brand = `${brand}/Global/Internship.svg`;
    }
}