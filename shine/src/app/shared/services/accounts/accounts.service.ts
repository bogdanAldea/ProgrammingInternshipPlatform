import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account, AccountWithPicture } from '../../models/account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  private readonly url: string  = 'https://localhost:44308/api/Accounts'

  constructor(private readonly httpClient: HttpClient) { }

  public getAccountsByRole = (role: string): Observable<AccountWithPicture[]> => {
    return this.httpClient.get<Account[]>(this.url, {params: {role: role}})
  }
}
