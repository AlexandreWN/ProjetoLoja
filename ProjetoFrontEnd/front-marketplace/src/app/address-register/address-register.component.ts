import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Address } from '../address';
import { Router } from '@angular/router';
import { tokenize } from '@angular/compiler/src/ml_parser/lexer';

@Component({
  selector: 'app-address-register',
  templateUrl: './address-register.component.html',
  styleUrls: ['./address-register.component.css']
})
export class AddressRegisterComponent implements OnInit {
  address : [Address] | undefined;
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  submit(){
    let street  = document.getElementById("street") as HTMLInputElement;
    let postal_code = document.getElementById("postal-code") as HTMLInputElement;
    let state = document.getElementById("state") as HTMLInputElement;
    let city = document.getElementById("city") as HTMLInputElement;
    let country = document.getElementById("country") as HTMLInputElement;
    let token = localStorage.getItem('authToken')
    console.log(street.value, postal_code.value, state.value, city.value, country.value)
    
    var data = JSON.stringify({
      "street": street.value,
      "postal_code": postal_code.value,
      "state": state.value,
      "city": city.value,
      "country": country.value
    });
    
    var config = {
      
      method: 'post',
      url: 'http://localhost:5141/Address/register',
      headers: { 
        'Content-Type': 'application/json', 
        'Authorization': 'Bearer ' + token
      },
      data : data
    };
    let instance = this;
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(data));
      instance.router.navigate(['/']);
    })
  }
}