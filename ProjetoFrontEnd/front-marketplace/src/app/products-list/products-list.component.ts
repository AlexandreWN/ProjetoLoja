import { Component, OnInit } from '@angular/core';
import { Product } from '../products';   
import axios from "axios";
import { Router } from '@angular/router';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products : [Product] | undefined;
  constructor(private router: Router) { }

  ngOnInit(): void {

    this.initiliaze();
   
  }
  async initiliaze(){
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Product/getAll',
      headers: { },
      data : ''
    };

    /*sincrona
    var instance  = this;
    var response = await axios(config);

    this.products = response.data;
    */
    var instance  = this;
    axios(config).then(function (response) {
      instance.products = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });

  }
  
  AddToWish(id : number, stockId : number){
    let token = localStorage.getItem('authToken')
    let document = localStorage.getItem('document')
  
    var data = JSON.stringify({
      "document": document,
      "productID" : id,
      "stockID" : stockId
    });
    
    var config = {
      method: 'post',
      url: 'http://localhost:5141/WishList/register',
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
      alert("Adicinado a WishList")
    })
    .catch(function (error) {
      if(error.response.status == 401){
        instance.router.navigate(['/login']);
      }
      else{
        console.log(error)
      }
    });
  }
}
