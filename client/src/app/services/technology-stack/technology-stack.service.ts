import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ITechnologyStackService } from 'src/app/application/service/ITechnologyStackService';
import { TechnologyStack, TechnologyStackResponse } from 'src/app/domain/internship-hub/technologyStack/TechnologyStack';

@Injectable({
  providedIn: 'root'
})
export class TechnologyStackService implements ITechnologyStackService {
  private readonly apiUrl: string = 'https://localhost:44308/api/TechnologyStack';
  
  public constructor(private httpClient: HttpClient) { }

  public getAllTechnologies(): Observable<TechnologyStack[]> {
    return this.httpClient.get<TechnologyStackResponse[]>(this.apiUrl)
    .pipe(map((response: TechnologyStackResponse[]) => {
      return response.map((response: TechnologyStackResponse) => new TechnologyStack(response))
    }))
  }
}
