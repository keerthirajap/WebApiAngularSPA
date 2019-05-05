import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';


import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse, HttpBackend } from '@angular/common/http';
import { Configuration } from '../infrastructure/app.constants';

import { UserAuthenticationModel } from '../login/models/userAuthenticationModel';

const helper = new JwtHelperService();


@Injectable()
export class AuthService {

  private userAuthDetails: string;

  private userLogin: UserAuthenticationModel = new UserAuthenticationModel();

  private http: HttpClient;
  private actionUrl: string;

  constructor(public jwtHelper: JwtHelperService, private configuration: Configuration, handler: HttpBackend) {
    this.actionUrl = this.configuration.serverApiVersionUrl + this.configuration.userManagementApiPath;
    this.http = new HttpClient(handler);
  }

  public getUserAuthenticationDetails(): UserAuthenticationModel {
    this.userAuthDetails = localStorage.getItem('userAuthentication');

    if (this.userAuthDetails === null || this.userAuthDetails === '') {
      return this.userLogin;
    }

    let jsonData: any = JSON.parse(this.userAuthDetails);

    this.userLogin.UserName = jsonData.UserName;
    this.userLogin.Token = jsonData.Token;
    this.userLogin.ExpiresOn = jsonData.ExpiresOn;

    return this.userLogin;
  }



  public isAuthenticated(): boolean {
    console.log(localStorage.getItem('userAuthentication'));
    const token = localStorage.getItem('userAuthentication');
    // Check wheter the token is expired and return true or false
    return !this.jwtHelper.isTokenExpired(token);
  }

  public setAntiforgeryToken(): void {
    var requestToken = this.getCookieValue('X-XSRF-TOKEN');

    console.log('requestToken' + requestToken);
    if (requestToken === '') {
      console.log('requestToken1' + requestToken);

      this.http
        .get<any>('https://localhost:44388/api/v1.0/AntiForgery/api/antiforgery', { observe: 'response' })
        .subscribe(response => {

          localStorage.setItem('X-XSRF-TOKEN', response.body.RequestToken);
          // if I am not mistaken "response.headers" should contain the "Set-Cookie" you are looking for
        });

    } else {


    }
  }

  public getCookieValue(cookieName: string) {
    const allCookies = decodeURIComponent(document.cookie).split('; ');
    for (let i = 0; i < allCookies.length; i++) {
      const cookie = allCookies[i];
      if (cookie.startsWith(cookieName + '=')) {
        return cookie.substring(cookieName.length + 1);
      }
    }
    return '';
  }

}
