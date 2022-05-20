import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Address } from '../address';

@Component({
  selector: 'app-address-register',
  templateUrl: './address-register.component.html',
  styleUrls: ['./address-register.component.css']
})
export class AddressRegisterComponent implements OnInit {
  address : [Address] | undefined;
  constructor() { }

  ngOnInit(): void {
  }
  submit(){
    let street  = document.getElementById("street") as HTMLInputElement;
    let postal_code = document.getElementById("postal-code") as HTMLInputElement;
    let state = document.getElementById("state") as HTMLInputElement;
    let city = document.getElementById("city") as HTMLInputElement;
    let country = document.getElementById("country") as HTMLInputElement;
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
        'Content-Type': 'application/json'
      },
      data : data
    };
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(data));
    })
  }
}