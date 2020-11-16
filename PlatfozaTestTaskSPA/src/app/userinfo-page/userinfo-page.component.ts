import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-userinfo-page',
  templateUrl: './userinfo-page.component.html',
  styleUrls: ['./userinfo-page.component.css']
})
export class UserinfoPageComponent implements OnInit {

  isAuthenticated: boolean = true
  user : User = null

  constructor(private http: HttpClient,
    private loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
    this.isAuthenticated = true
    if (this.loginService.isAuthenticated){
      this.http.get<User>('/user/userinfo', {'headers': this.loginService.JwtHeader}).subscribe(
        response =>{
          this.user = response
      },
      () => this.router.navigate(['/login']))
    }
    else {
      this.router.navigate(['/login'])
    }
  }

  signOut(){
    this.loginService.logout()
    this.router.navigate([''])
  }

}
