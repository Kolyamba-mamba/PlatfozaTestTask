import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { UserinfoPageComponent } from './userinfo-page/userinfo-page.component';

const routes: Routes = [
    {path: '', children: [
        { path: '', redirectTo: '/login', pathMatch: 'full'}
    ]},
    {path: 'login', component: LoginPageComponent},
    {path: 'info', component: UserinfoPageComponent}
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