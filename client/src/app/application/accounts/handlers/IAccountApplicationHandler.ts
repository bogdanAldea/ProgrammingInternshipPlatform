import { Observable } from "rxjs";
import { PartialAccount } from "src/app/domain/accounts/PartialAccount";

export abstract class IAccountApplicationHandler {
    public abstract getAllAccounts(): Observable<PartialAccount[]>;
    public abstract getAllAccountsByRole(role: string): Observable<PartialAccount[]>;
}