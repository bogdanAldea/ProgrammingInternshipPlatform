import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, from, switchMap } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';


@Injectable()
export class NewAuthenticationInterceptor implements HttpInterceptor {

  public constructor(private authService: AuthenticationService) {}

  public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    return from(this.authService.getAccessToken()).pipe(
      switchMap(token => {
        if (token) {
          const clonedRequest = request.clone({
            setHeaders: {
              Authorization: `Bearer ${token}`
            }
          });

          return next.handle(clonedRequest);
        } else {
          return next.handle(request);
        }
      })
    );
  }
}
