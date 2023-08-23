import { PartialAccount } from "src/app/domain/accounts/PartialAccount";
import { IAccountsService } from "../../service/IAccountService";
import { IAccountApplicationHandler } from "./IAccountApplicationHandler";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root'
  })
export class AccountApplicationHandler implements IAccountApplicationHandler {

    public constructor(private service: IAccountsService) {}

    public getAllAccounts = (): Observable<PartialAccount[]> => {
        return this.service.getAllAccounts();
    }

    public getAllAccountsByRole = (role: string): Observable<PartialAccount[]> => {
        return this.service.getAllAccountsByRole(role);
    }
}