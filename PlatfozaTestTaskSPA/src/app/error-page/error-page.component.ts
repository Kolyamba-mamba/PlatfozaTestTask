import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.css']
})
export class ErrorPageComponent implements OnInit {

  errorMessage: string

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<{error: string}>('/user/error').subscribe(
      () =>{
        console.log("Ok")
    },
    ({error}) => {
      this.errorMessage = error
    })
  }

}
