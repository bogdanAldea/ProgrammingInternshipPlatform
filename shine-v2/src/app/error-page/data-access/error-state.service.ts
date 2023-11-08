import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorStateService {
  private error: any;

  public setError = (error: any): void => this.error = error;
  public getError = (): any => this.error; 
}
