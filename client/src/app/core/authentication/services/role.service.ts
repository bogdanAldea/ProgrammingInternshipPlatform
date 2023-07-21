import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from '../../accounts/contracts/role';
import { ApiRoutes } from '../../configurations/api-routes';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  public constructor(private httpClient: HttpClient) { }

  public getAdministratorRole = (): Observable<Role> => {
    const url: string = ApiRoutes.Roles.AdminRole;
    return this.httpClient.get<Role>(url);
  }
}
