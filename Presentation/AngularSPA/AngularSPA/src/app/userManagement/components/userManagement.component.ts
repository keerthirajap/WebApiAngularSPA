// For NgModule
import { NgModule } from '@angular/core';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { from } from 'rxjs';
// import * as $ from 'jquery';
declare var $: any;

// Custom Service Imports
import { UserManagementService } from '../services/userManagement.service';

// Custom Component Imports
import { UserModel } from '../../models/userModel';
import { ListResponse, SingleResponse, Response } from '../../models/apiResponse';

@Component({
    templateUrl: '../views/userManagement.component.html'
})


export class UserManagementComponent implements OnInit {

    private userDetailsResponse: SingleResponse<UserModel>;

    constructor(
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private userManagementService: UserManagementService) {

    }

    getUserDetails(): void {
        this.userManagementService.getUserDetailsByUserName('string')
        .subscribe(
          (singleResponse) => {
            this.userDetailsResponse = singleResponse;
            console.log(this.userDetailsResponse);


          },
          error => () => {
            console.error('Error');
          }
        );
    }
    ngOnInit(): void {
    }
}
