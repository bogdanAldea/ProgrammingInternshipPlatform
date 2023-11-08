import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  private readonly baseUrl: string = 'https://localhost:44308/api/Accounts';

  constructor(private readonly httpClient: HttpClient) { }

  public getAccountById = (accountId: string): Observable<Account> => {
    const url = `${this.baseUrl}/${accountId}`;
    return this.httpClient.get<Account>(url);
  }
}

export interface Account {
  displayName: string;
  email: string;
  givenName: string;
  surname: string;
  initials: string;
  jobTitle: string;
}
