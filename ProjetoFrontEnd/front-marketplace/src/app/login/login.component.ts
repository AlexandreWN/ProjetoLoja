import { Component, OnInit } from '@angular/core';
import axios from "axios";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor() {
    
   }

  ngOnInit(): void {


  }


  login(){
    let user  = document.getElementById("username") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;
    var data = JSON.stringify({
      "login": user,
      "passwd": passwd
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
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
    })
  }
}
