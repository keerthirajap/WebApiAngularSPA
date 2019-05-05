// For NgModule
import { NgModule } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { from } from 'rxjs';
import swal from 'sweetalert2';

// import * as $ from 'jquery';
declare var $: any;

import { UserLogin } from '../models/userLogin';
import { UserAuthenticationModel } from '../models/userAuthenticationModel';
import { ListResponse, SingleResponse, Response } from '../../models/apiResponse';

// Custom Service Imports
import { UserLoginService } from '../services/userLogin.service';
import { AuthService } from '../../infrastructure/app.auth.service';

@Component({
  templateUrl: '../views/userLogin.component.html'
})


export class UserLoginComponent implements OnInit {
  public personForm: FormGroup;
  public userLogin: UserLogin = new UserLogin();
  private userLoginResponse: SingleResponse<UserAuthenticationModel>;
  public errors: string[];
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthService,
    private userLoginService: UserLoginService) {

    this.authService.setAntiforgeryToken();

  }

  private markFormGroupTouched(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach(control => {
      control.markAsTouched();

      if (control.controls) {
        this.markFormGroupTouched(control);
      }
    });
  }

  loginUserButtonClick(): void {
    if (!this.personForm.valid) {
      this.markFormGroupTouched(this.personForm);
    }
    if (this.personForm.valid) {
      // this.userLogin.Password = this.personForm.value.Password;
      // this.userLogin.UserName =  this.personForm.value.UserName;
      this.userLogin = new UserLogin(this.personForm.value);
      this.userLoginService.authenticateUser(this.userLogin)
        .subscribe(
          (singleResponse) => {
            this.userLoginResponse = singleResponse;
            console.log(this.userLoginResponse.Message);
            localStorage.setItem('userAuthentication', JSON.stringify(this.userLoginResponse.Model));
            this.router.navigateByUrl('/');

            const Toast = swal.mixin({
              toast: true,
              position: 'top-end',
              showConfirmButton: false,
              timer: 4000
            });

            Toast.fire({
              type: 'success',
              title: 'Signed in successfully'
            });
          },
          error => {

            if (error.status === 400) {
              console.warn(error);

              if (error.error.Message === 'User Name or Password is Incorrect. Please try again') {
                swal.fire({
                  type: 'error',
                  title: 'Oops...',
                  text: error.error.Message,

                });
              }
              else if (error.error.Message === 'One or More Validation error(s) occured') {
                for (var key in error.error.Model) {

                  this.personForm.controls[key].setErrors({ invalid: true });
                }
              }
            }
          },
        );
    }
  }
  ngOnInit(): void {



    this.personForm = this.fb.group({
      UserName: ['', [
        Validators.required,
        Validators.minLength(4)
      ]],
      Password: ['', Validators.required]
    });
    this.errors = [];

  }
}
