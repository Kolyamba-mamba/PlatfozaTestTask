import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-exception-page',
  templateUrl: './exception-page.component.html',
  styleUrls: ['./exception-page.component.css']
})
export class ExceptionPageComponent implements OnInit {

  exceptionMessage: string

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('/user/exception').subscribe(
      () =>{
        console.log("Ok")
    },
    () => {
      this.exceptionMessage = "Exception!"
    })
  }

}
