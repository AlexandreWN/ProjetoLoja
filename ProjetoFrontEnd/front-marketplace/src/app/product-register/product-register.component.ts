import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '../stores';
@Component({
  selector: 'app-product-register',
  templateUrl: './product-register.component.html',
  styleUrls: ['./product-register.component.css'],
})
export class ProductRegisterComponent implements OnInit {
  constructor(private router: Router, private route: ActivatedRoute) {}
  stores: Array<Store> = [];
  productid : number
  cancel() {
    let campos = document.getElementsByClassName('form-control');
    for (let i = 0; i < campos.length; i++) {
      let campo = campos[i] as HTMLInputElement;
      campo.value = '';
    }
  }

  ngOnInit(): void {
    let token = localStorage.getItem('authToken');
    let document = localStorage.getItem('document');
    if (token == null || document == null) {
      this.router.navigate(['/login']);
    } else {
      const routeParams = this.route.snapshot.paramMap;
      console.log(document);
      this.initiliaze(document);
    }
  }

  async initiliaze(document) {
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Store/getOwnerStore/' + document,
      headers: {},
      data: '',
    };
    var instance = this;
    axios(config)
      .then(function (response) {
        instance.stores = response.data;
        console.log(response.data);
      })
      .catch(function (error) {
        if (error.response.status == 401) {
          instance.router.navigate(['/login']);
        } else {
          console.log(error);
        }
      });
  }

  rollback() {
    history.back();
  }

 async save() {
    let token = localStorage.getItem('authToken');
    let name = document.getElementById('name') as HTMLInputElement;
    let barcode = document.getElementById('barcode') as HTMLInputElement;
    let description = document.getElementById('description') as HTMLInputElement;
    let image = document.getElementById('image') as HTMLInputElement;
    let quatity = document.getElementById('quantity') as HTMLInputElement;
    let unity_price = document.getElementById('unity_price') as HTMLInputElement;
    let storeid = document.getElementById('storeid') as HTMLInputElement;


    var data = JSON.stringify({
      name: name.value,
      bar_code: barcode.value,
      description: description.value,
      image: image.value,
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5141/Product/register',
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + token,
      },
      data: data,
    };

    let instance = this;

     let response = await axios(config)
      this.productid = response.data.id;


       var dataStocks = JSON.stringify({
         
        quantity: Number(quatity.value),
        unit_price: Number(unity_price.value),
        storeid: Number(storeid.value),
        productid:this.productid
      });


       config = {
        method: 'post',
        url: 'http://localhost:5141/Stock/register',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + token,
        },
        data: dataStocks,
      };
       instance = this;
      axios(config)
        .then(function (response) {})
        .catch(function (error) {
          if (error.response.status == 401) {
            instance.router.navigate(['/login']);
          } else {
            console.log(error);
          }
        });

        this.cancel()
        alert("Cadastrado com sucesso!")
  }

  
}
