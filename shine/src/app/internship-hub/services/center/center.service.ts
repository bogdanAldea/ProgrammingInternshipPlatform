import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConvertedFromEnum } from 'src/app/shared/models/convertedFromEnum';

@Injectable({
  providedIn: 'root'
})
export class CenterService {
  private readonly url: string  = 'https://localhost:44308/api/Centers'

  constructor(private httpClient: HttpClient) { }

  public getAllCentersAtOrganisation = (): Observable<ConvertedFromEnum[]> => {
    return this.httpClient.get<ConvertedFromEnum[]>(this.url)
  }
}
