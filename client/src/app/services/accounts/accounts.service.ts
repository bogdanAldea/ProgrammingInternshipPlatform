import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IAccountsService } from 'src/app/application/service/IAccountService';
import { PartialAccount, PartialAccountResponse } from 'src/app/domain/accounts/PartialAccount';

@Injectable({
  providedIn: 'root'
})
export class AccountsService implements IAccountsService {
  private readonly apiUrl: string = 'https://localhost:44308/api/Accounts';

  constructor(private httpClient: HttpClient) { }

  public getAllAccounts = (): Observable<PartialAccount[]> => {
    return this.httpClient.get<PartialAccountResponse[]>(this.apiUrl)
      .pipe(map((response: PartialAccountResponse[]) => {
        return response.map(account => new PartialAccount(account))
      }))
  }

  public getAllAccountsByRole = (role: string): Observable<PartialAccount[]> => {
    const params = new HttpParams().set('role', role);
    return this.httpClient.get<PartialAccountResponse[]>(this.apiUrl, {params})
      .pipe(map((response: PartialAccountResponse[]) => {
        return response.map(account => new PartialAccount(account))
      }))
  }
}
