import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WishList } from '../wishlists';
import axios from "axios";
@Component({
  selector: 'app-wishlist-detail',
  templateUrl: './wishlist-detail.component.html',
  styleUrls: ['./wishlist-detail.component.css']
})
export class WishlistDetailComponent implements OnInit {
  titlePage = "WishList"
  wishlist : [WishList] | undefined;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.initiliaze(Number(routeParams.get('userId')));
  }

  async initiliaze(id){
    var config = {
      method: 'get',
      url: 'http://localhost:5141/WishList/get/' + 1,
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
      instance.wishlist = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });

  }
}