import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class ApiFailureInterceptor implements HttpInterceptor {

  public constructor(private router: Router) {}

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status >= 400) {
          this.router.navigate(['./', error.status.toString()])
        }
        return throwError(() => new Error(error.message))
      })
    );
  }
}
