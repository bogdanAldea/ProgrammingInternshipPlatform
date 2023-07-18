import { Account } from "./account";
import { Role } from "./role";

export interface AccountWithRoles extends Account
{
    roles: Role[];
}