import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICenterApplicationHandler } from 'src/app/application/centers/handlers/ICenterApplicationHandler';
import { Center } from 'src/app/domain/internship-hub/centers/center';

@Injectable({
  providedIn: 'root'
})
export class CentersController {

  constructor(private handler: ICenterApplicationHandler) { }

  public getAllCenters = (): Observable<Center[]> => {
    return this.handler.getAllCenters();
  }
}
