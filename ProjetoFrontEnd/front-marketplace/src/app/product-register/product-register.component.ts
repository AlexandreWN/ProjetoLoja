import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';
@Component({
  selector: 'app-product-register',
  templateUrl: './product-register.component.html',
  styleUrls: ['./product-register.component.css']
})
export class ProductRegisterComponent implements OnInit {

  constructor() { }

  cancel(){
    //$("input")
  }



  ngOnInit(): void {
  }
  save(){
    let token = localStorage.getItem('authToken')
    let name  = document.getElementById("name") as HTMLInputElement;
    let barcode = document.getElementById("barcode") as HTMLInputElement;
    let description = document.getElementById("description") as HTMLInputElement;
    let image = document.getElementById("image") as HTMLInputElement;
    
    var data = JSON.stringify({
      "name": name.value,
      "bar_code": barcode.value,
      "description": description.value,
      "image": image.value,
    });
    
    var config = {
      
      method: 'post',
      url: 'http://localhost:5141/Product/register',
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' +token
      },
      data : data
    };
    let instance = this;
    axios(config)
    .then(function (response) {
      console.log(data);
    })
  }
}
