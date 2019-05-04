import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

const helper = new JwtHelperService();

@Injectable()
export class AuthService {

  constructor(public jwtHelper: JwtHelperService) { }

  public getToken(): string {
    return localStorage.getItem('userAuthentication');
  }

  public isAuthenticated(): boolean {
    console.log (localStorage.getItem('userAuthentication'));
    const token = localStorage.getItem('userAuthentication');
    // Check wheter the token is expired and return true or false
    return !this.jwtHelper.isTokenExpired(token);
  }
}
