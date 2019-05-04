// For NgModule
import { NgModule } from '@angular/core';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { from } from 'rxjs';
// import * as $ from 'jquery';
declare var $: any;

import { UserLogin } from '../models/userLogin';
import { UserAuthenticationModel } from '../models/userAuthenticationModel';
import { ListResponse, SingleResponse, Response } from '../../models/apiResponse';

// Custom Service Imports
import { UserLoginService } from '../services/userLogin.service';

@Component({
    templateUrl: '../views/userLogin.component.html'
})


export class UserLoginComponent implements OnInit {

    public userLogin: UserLogin = new UserLogin();
    private userLoginResponse: SingleResponse<UserAuthenticationModel>;
    constructor(
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private userLoginService: UserLoginService) {

    }

    loginUserButtonClick(): void {
        this.userLoginService.authenticateUser(this.userLogin)
        .subscribe(
          (singleResponse) => {
            this.userLoginResponse = singleResponse;
            console.log(this.userLoginResponse.Message);
            localStorage.setItem('userAuthentication',  this.userLoginResponse.Model.Token);
            this.router.navigateByUrl('/');
          },
          error => () => {
            console.error('Error');
          }
        );
    }
    ngOnInit(): void {
    }
}
