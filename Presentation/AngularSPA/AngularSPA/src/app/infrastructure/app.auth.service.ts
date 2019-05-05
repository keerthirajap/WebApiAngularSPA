import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';


import { UserAuthenticationModel } from '../login/models/userAuthenticationModel';

const helper = new JwtHelperService();


@Injectable()
export class AuthService {

  private userAuthDetails: string;

  private userLogin: UserAuthenticationModel = new UserAuthenticationModel();

  constructor(public jwtHelper: JwtHelperService) { }

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
    console.log (localStorage.getItem('userAuthentication'));
    const token = localStorage.getItem('userAuthentication');
    // Check wheter the token is expired and return true or false
    return !this.jwtHelper.isTokenExpired(token);
  }
}
