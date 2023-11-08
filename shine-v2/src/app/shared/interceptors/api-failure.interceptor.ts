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
import { ErrorStateService } from 'src/app/error-page/data-access/error-state.service';

@Injectable()
export class ApiFailureInterceptor implements HttpInterceptor {

  public constructor(private router: Router, private errorStateService: ErrorStateService) {}

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status >= 400 && error.status !== 401) {
          this.errorStateService.setError(error)
          this.router.navigate(['./error'])
        }

        if(error.status === 401) {
          this.router.navigate(['/sign-in'])
        }
        return throwError(() => new Error(error.message))
      })
    );
  }
}
