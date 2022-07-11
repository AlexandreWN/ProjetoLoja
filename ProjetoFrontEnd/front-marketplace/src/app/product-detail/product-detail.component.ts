import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../products';
import axios from "axios";
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlePage = "Product Detail"
  product : Product | undefined;
  cnpj : string = ""
  bar_code : string  = ""
  value : number = -1
  doc : string | undefined
  token : string | undefined

  constructor(private route: ActivatedRoute){ }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.initiliaze(Number(routeParams.get('productId')));
  }

  async initiliaze(id){
    this.doc = localStorage.getItem('document')?.toString()
    this.token = localStorage.getItem('authToken')?.toString()

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
      console.log(response.data)
    })
    .catch(function (error) {
      console.log(error);
    });

  }

  getDados(cnpj : string, bar_code : string, price : number){
    this.cnpj = cnpj
    this.bar_code = bar_code
    this.value = price


    console.log(this.cnpj)
  }

  comprar(){
    var date = new Date
    var cnpj = this.cnpj
    var documento = this.doc
    var bar_code = this.bar_code
    var purchase_value = this.value
    var valorRandom = (Math.floor(Math.random() * 1999999) + 1000000).toString();
    var valorRandomFiscal = (Math.floor(Math.random() * 1999999) + 1000000).toString();
    var payment_type = document.getElementById("type") as HTMLInputElement;

    var data = {
      date_purchase : date,
      purchase_value : purchase_value,
      payment_type : payment_type.value,
      purchase_status : 2,
      number_confirmation : valorRandom,
      number_nf : valorRandomFiscal,
      client : {
        document : documento
      },
      store : {
        cnpj : cnpj
      },
      productsDTO : {
        bar_code : bar_code
      }
    }
    var instance = this

    var config = {
      method: 'post',
      url: 'http://localhost:5141/Purchase/register', 
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' +this.token
      },
      data : JSON.stringify(data)
    };

    axios(config).then(function (response) {
      console.log(response.data)
    })
    .catch(function (error) {
      console.log(error);  
    });
  }
}