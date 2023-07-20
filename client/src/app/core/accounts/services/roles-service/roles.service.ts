import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Role } from '../../contracts/role';
import { Observable } from 'rxjs';
import { ApiRoutes } from 'src/app/core/configurations/api-routes';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private httpClient: HttpClient) { }

  public getAllRoles = (): Observable<Role[]> => {
    const base: string = ApiRoutes.Roles.Base;
    return this.httpClient.get<Role[]>(base);
  }
}
