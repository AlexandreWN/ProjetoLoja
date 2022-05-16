import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product,products } from '../products';
import axios from "axios";
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlePage = "Product Detail"
  product : Product | undefined;

  
  constructor(private route: ActivatedRoute){ }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;


    this.initiliaze(Number(routeParams.get('productId')));
   
  }

  async initiliaze(id){
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Product/get/' + id,
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
      //console.table(response.data);
      instance.product = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });

  }
}