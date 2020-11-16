import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit, OnDestroy {

  loginForm: FormGroup
  aSub: Subscription
  isSuccess: boolean = true

  constructor(private auth: LoginService, 
    private router: Router, 
    private route: ActivatedRoute) { }
  
  ngOnDestroy(): void {
    if(this.aSub){
      this.aSub.unsubscribe()
    }
  }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required])
    })

    this.route.queryParams.subscribe((params: Params) => {})
  }

  onSubmit(){
    this.loginForm.disable()
    this.isSuccess = true

    this.aSub = this.auth.login(this.loginForm.value).subscribe(
      () => this.router.navigate(['/info']),
      () => {
        this.isSuccess = false
        this.loginForm.enable()
      }
    )
  }

}
