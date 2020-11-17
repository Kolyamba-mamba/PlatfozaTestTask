import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './error-page/error-page.component';
import { ExceptionPageComponent } from './exception-page/exception-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { UserinfoPageComponent } from './userinfo-page/userinfo-page.component';

const routes: Routes = [
    {path: '', children: [
        { path: '', redirectTo: '/login', pathMatch: 'full'}
    ]},
    {path: 'login', component: LoginPageComponent},
    {path: 'info', component: UserinfoPageComponent},
    {path: 'error', component: ErrorPageComponent},
    {path: 'exception', component: ExceptionPageComponent}
]

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule{

}