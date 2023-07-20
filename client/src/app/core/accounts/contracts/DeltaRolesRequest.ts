import { Role } from "./role";

export interface DeltaRolesRequest {
    rolesToAdd: Role[];
    rolesToRemoved: Role[];
}