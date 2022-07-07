import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import axios from "axios";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})



export class LoginComponent implements OnInit {
  
  loginType :  string = "Client"



  constructor(private router: Router) { }

  ngOnInit(): void {


  }

  changeLogin(){
    let log = document.getElementById('flexSwitchCheckDefault') as HTMLInputElement;
    console.log(log.checked)
    if(log.checked) this.loginType = "Owner"
    else this.loginType = "Client"
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
      url: '',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };

    if(this.loginType == "Client") config.url= 'http://localhost:5141/Client/login'
    else config.url= 'http://localhost:5141/Owner/login'

    console.log(config)

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
