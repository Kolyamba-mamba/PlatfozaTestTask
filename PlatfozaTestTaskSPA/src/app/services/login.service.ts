import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Account } from '../models/account';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class LoginService{
    constructor(private http: HttpClient){}

    login(account: Account): Observable<{isSuccess:boolean, token: string}>{
        return this.http.post<{isSuccess:boolean, token: string}>('/user/login', account)
        .pipe(
            tap(
                ({token}) => {
                    localStorage.setItem('auth-token', token)
                }
            )
        )
    }

    get JwtHeader(){
        const headers = new HttpHeaders()
        .set('Accept', 'application/json')
        .set('Authorization', "Bearer " + localStorage.getItem('auth-token'))
        return headers
    }

    logout(){
        localStorage.clear()
    }

    get getToken(): string{
        return localStorage.getItem('auth-token')
    }

    get isAuthenticated(): boolean{
        return localStorage.getItem('auth-token') !== null
    }


}