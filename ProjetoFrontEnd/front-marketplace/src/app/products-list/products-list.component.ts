import { Component, OnInit } from '@angular/core';
import { Product } from '../products';   
import axios from "axios";


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products : [Product] | undefined;
  constructor() { }

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
}
