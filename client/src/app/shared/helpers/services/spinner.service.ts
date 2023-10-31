import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, finalize, switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  private activeRequests = 0;
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$ = this.loadingSubject.asObservable();

  constructor() {}

  add<T>(observable: Observable<T>): Observable<T> {
    return this.loading$.pipe(
      switchMap((isLoading) => {
        if (!isLoading) {
          this.show();
        }
        return observable.pipe(
          finalize(() => this.hide())
        );
      })
    );
  }

  private show() {
    this.activeRequests++;
    this.loadingSubject.next(true);
  }

  private hide() {
    this.activeRequests--;
    if (this.activeRequests <= 0) {
      this.loadingSubject.next(false);
      this.activeRequests = 0;
    }
  }
}
