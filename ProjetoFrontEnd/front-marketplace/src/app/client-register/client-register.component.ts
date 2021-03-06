import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';
@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  loginType :  string = "Client"
  constructor(private router: Router) { }

  changeLogin(){
    let log = document.getElementById('flexSwitchCheckDefault') as HTMLInputElement;
    console.log(log.checked)
    if(log.checked) this.loginType = "Owner"
    else this.loginType = "Client"
  }



  ngOnInit(): void {
  }
  save(){
    let name  = document.getElementById("name") as HTMLInputElement;
    let phone = document.getElementById("phone") as HTMLInputElement;
    let email = document.getElementById("email") as HTMLInputElement;
    let login = document.getElementById("login") as HTMLInputElement;
    let dateOfBirth = document.getElementById("date-of-birth") as HTMLInputElement;
    let password = document.getElementById("password") as HTMLInputElement;
    let documento = document.getElementById("document") as HTMLInputElement;
    
    let street = document.getElementById("street") as HTMLInputElement;
    let state = document.getElementById("state") as HTMLInputElement;
    let city = document.getElementById("city") as HTMLInputElement;
    let country = document.getElementById("country") as HTMLInputElement;
    let postal_code = document.getElementById("postal-code") as HTMLInputElement;
    
    var data = JSON.stringify({
      "name": name.value,
      "phone": phone.value,
      "email": email.value,
      "date_of_birth": dateOfBirth.value,
      "document": documento.value,
      "login": login.value,
      "passwd": password.value,
      "address": {
        "street": street.value,
        "state": state.value,
        "city":city.value,
        "country":country.value,
        "postal_code":postal_code.value
      }
    });
    
    var config = {
      
      method: 'post',
      url: '',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    if(this.loginType == "Client") config.url = 'http://localhost:5141/Client/register'
    else config.url = 'http://localhost:5141/Owner/register'
    let instance = this;
    axios(config)
    .then(function (response) {
      console.log(data);
    })
  }
}
