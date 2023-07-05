import { RoleResponse } from "./role-response";

export interface AccountWithRoles
{
    firstName: string;
    lastName: string;
    email: string;
    joiningDate: string;
    roles: RoleResponse[];
}