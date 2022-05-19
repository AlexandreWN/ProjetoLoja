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

  async initiliaze(){
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Address/getAll',
      headers: { },
      data : ''
    };
    var instance  = this;
    axios(config).then(function (response) {
      instance.address = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });

  }
}
