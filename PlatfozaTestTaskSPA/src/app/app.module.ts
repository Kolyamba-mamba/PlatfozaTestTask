import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { AppRoutingModule } from './app-routing.module';
import { UserinfoPageComponent } from './userinfo-page/userinfo-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { ExceptionPageComponent } from './exception-page/exception-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    UserinfoPageComponent,
    ErrorPageComponent,
    ExceptionPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
