// For NgModule
import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';

// For imports
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

// For Declarations
import { AppComponent } from './app.component';

import { TokenInterceptor } from './infrastructure/app.tokenInterceptor';
import { AuthService } from './infrastructure/app.auth.service';

import { UserLoginComponent } from './login/components/userLogin.component';
import { UserManagementComponent } from './userManagement/components/userManagement.component';

// For Services
import { UserLoginService } from './login/services/userLogin.service';
import { UserManagementService } from './userManagement/services/userManagement.service';

const appRoutes: Routes = [
  { path: 'login', component: UserLoginComponent },
  { path: 'userManagement', component: UserManagementComponent },
];

export function tokenGetter() {
  return localStorage.getItem('access_token');
}


@NgModule({
  declarations: [
    AppComponent,

    UserLoginComponent,
    UserManagementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    AuthService,
    UserLoginService,
    UserManagementService],
  bootstrap: [AppComponent]

})
export class AppModule { }
