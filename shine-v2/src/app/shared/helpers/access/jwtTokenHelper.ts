import { jwtDecode } from "jwt-decode";

export class JwtTokenHelper {
    private readonly token: any;
    private readonly oidKey = 'oid';
    private readonly rolesKey = '';

    public constructor() {
        const raw = localStorage.getItem('access_token')
        this.token = this.decodeToken(raw);
    }

    public getAccountIdentifier = (): string => {
        return this.token[this.oidKey];
    }

    public getAccountRoles = (): ReadonlyArray<string> => {
        return this.token[this.rolesKey];
    }

    private decodeToken = (token: any): any => {
        if (token)
        return jwtDecode(token);
    }
}