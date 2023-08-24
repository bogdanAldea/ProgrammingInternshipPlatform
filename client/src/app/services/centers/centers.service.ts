import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ICenterService } from 'src/app/application/service/ICenterService';
import { Center, CenterResponse } from 'src/app/domain/internship-hub/centers/center';

@Injectable({
  providedIn: 'root'
})
export class CentersService implements ICenterService {
  private readonly apiUrl: string = 'https://localhost:44308/api/Centers';
  
  public constructor(private httpClient: HttpClient) { }

  public getAllServices = (): Observable<Center[]> => {
    return this.httpClient.get<CenterResponse[]>(this.apiUrl)
    .pipe(map((response: CenterResponse[]) => {
      return response.map((response: CenterResponse) => new Center(response))
    }))
  };
}
