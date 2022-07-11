import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { WishList } from '../wishlists';
import axios from "axios";
import { ProductDetailComponent } from '../product-detail/product-detail.component';
@Component({
  selector: 'app-wishlist-detail',
  templateUrl: './wishlist-detail.component.html',
  styleUrls: ['./wishlist-detail.component.css']
})
export class WishlistDetailComponent implements OnInit {
  titlePage = "WishList"
  wishlist : [WishList] | undefined;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.initiliaze(Number(routeParams.get('userId')));
  }

  async initiliaze(id){
    let token = localStorage.getItem('authToken')
    let document = localStorage.getItem('document')
    console.log(token);
    var config = {
      method: 'get',
      url: 'http://localhost:5141/WishList/get/' + document,
      headers: {'Authorization': 'Bearer ' +token},
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
      instance.wishlist = response.data;
      console.log(response.data)
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
  
  detalhe(stockid){
    var instance  = this;
    instance.router.navigate(['/product/'+stockid]);
  }
  
  remove(stockId){
    let token = localStorage.getItem('authToken')
    let document = localStorage.getItem('document')
  
    var data = JSON.stringify({
      "document": document,
      "stockID" : stockId
    });
    
    var config = {
      method: 'delete',
      url: 'http://localhost:5141/WishList/delet/' + stockId +"/"+ document,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' +token
      },
      data : data
    };
    let instance = this;
    axios(config)
    .then(function (response) {
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