import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './app.auth.service';
import { Observable, throwError } from 'rxjs';
import { EMPTY } from 'rxjs';

import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import {formatDate} from '@angular/common';

import { UserAuthenticationModel } from '../login/models/userAuthenticationModel';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(public auth: AuthService, private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let userLogin: UserAuthenticationModel = new UserAuthenticationModel();

    userLogin = this.auth.getUserAuthenticationDetails();

    if (userLogin.Token === undefined ||
      formatDate(userLogin.ExpiresOn, 'yyyy/MM/dd HH:mm:ss', 'en')
       <= formatDate(new Date(), 'yyyy/MM/dd HH:mm:ss', 'en')) {
      console.warn('Token Invalid. Redirecting to Login Screen');
      // not logged in so redirect to login page with the return url and return false
      this.router.navigate(['/login']);
      return EMPTY;

    } else {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${userLogin.Token}`
        }
      });
    }


    return next.handle(request);
  }
}
