export namespace ApiRoutes
{
    const server: string = 'https://localhost:7049/api';

    export class Account 
    {
        public static Base = `${server}/UserAccounts`
        public static Signup = `${this.Base}/`;
        public static Signin = `${this.Base}/`;
    }

    export class Roles 
    {
        public static Base = `${server}/Roles`;
        public static AdminRole = `${this.Base}/administrator`;
    }

    export class Organisation
    {
        public static Base = `${server}/Organisations`;
        public static AllAccounts = 'user-accounts';
    }
}