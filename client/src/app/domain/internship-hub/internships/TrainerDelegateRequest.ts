import { BaseEnumResponse } from "../../base/BaseEnumEntity";

export interface TrainerDelegateRequest {
    accountId: string;
    technologies: BaseEnumResponse[]
}