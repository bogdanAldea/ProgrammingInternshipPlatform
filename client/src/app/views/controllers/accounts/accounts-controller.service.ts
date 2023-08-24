import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAccountApplicationHandler } from 'src/app/application/accounts/handlers/IAccountApplicationHandler';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';

@Injectable({
  providedIn: 'root'
})
export class AccountsController {

  constructor(private handler: IAccountApplicationHandler) { }

  public getAllAccounts = (): Observable<PartialAccount[]> => {
    return this.handler.getAllAccounts();
  }

  public getAllAccountsByRole = (role: string): Observable<PartialAccount[]> => {
    return this.handler.getAllAccountsByRole(role);
  }
}
