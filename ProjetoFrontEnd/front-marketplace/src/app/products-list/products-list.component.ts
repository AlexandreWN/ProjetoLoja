import { Component, OnInit } from '@angular/core';
import { products} from '../products';   
import axios from "axios";


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products = products;
  constructor() { }

  ngOnInit(): void {

    var config = {
      method: 'get',
      url: 'http://localhost:5141/Product/getAll',
      headers: { },
      data : ''
    };
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error);
    });
  }
}
