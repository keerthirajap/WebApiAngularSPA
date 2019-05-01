// For NgModule
import { NgModule } from '@angular/core';

// For imports
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

// For Declarations
import { AppComponent } from './app.component';

import { UserLoginComponent } from './login/components/userLogin.component';

// For Services
import { UserLoginService } from './login/services/userLogin.service';

const appRoutes: Routes = [
  { path: 'login', component: UserLoginComponent },
];

@NgModule({
  declarations: [
    AppComponent,

    UserLoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UserLoginService],
  bootstrap: [AppComponent]

})
export class AppModule { }
