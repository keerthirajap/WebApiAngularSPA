import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Configuration } from '../../infrastructure/app.constants';

// Custom Component Imports
import { UserLogin } from '../models/userLogin';
import { ListResponse, SingleResponse, Response } from '../../models/apiResponse';


@Injectable()
export class UserLoginService {

    private actionUrl: string;
    private apiVersion: string;
    public userLogin: UserLogin = new UserLogin();
    private userLoginResponse: SingleResponse<UserLogin>;

    constructor(private http: HttpClient, private configuration: Configuration) {
        this.actionUrl = this.configuration.serverWithApiUrl + this.configuration.userManagementApiPath;
        this.apiVersion = this.configuration.apiVersion;
    }

    public authenticateUser(user: UserLogin): Observable<SingleResponse<UserLogin>> {
        
        return this.http.post<SingleResponse<UserLogin>>(this.actionUrl + 'AuthenticateUser' + this.apiVersion
            , user)
            .pipe(catchError(this.handleError));
    }



    private handleError(error: HttpErrorResponse) {
        console.error(error);
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
                `Backend returned code ${error.status}, ` +
                `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return throwError(error);
    }
}
