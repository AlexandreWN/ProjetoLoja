import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import axios from "axios";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor(private router: Router) { }

  ngOnInit(): void {


  }


  login(){
    let user  = document.getElementById("username") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;
    var data = JSON.stringify({
      "login": user.value,
      "passwd": passwd.value
    });
    console.log(user.value, passwd.value)
    var config = {      
      method: 'post',
      url: 'http://localhost:5141/Client/login',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    let instance = this;
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      localStorage.setItem('authToken',response.data['token']);
      localStorage.setItem('document',response.data['document']);
      instance.router.navigate(['/']);
    }).catch(function (error) {
      console.log(error);
      localStorage.removeItem('authToken');
    });
  }
}
