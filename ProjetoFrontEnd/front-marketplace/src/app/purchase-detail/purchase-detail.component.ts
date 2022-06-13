import { Component, OnInit } from '@angular/core';
import { Purchase } from '../purchases';
import axios from "axios";
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-purchase-detail',
  templateUrl: './purchase-detail.component.html',
  styleUrls: ['./purchase-detail.component.css']
})
export class PurchaseDetailComponent implements OnInit {
  titlePage = "Purchase Detail"
  purchase : Purchase | undefined;
  constructor(private route: ActivatedRoute){ }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.initiliaze(Number(routeParams.get('purchaseId')));
  }
  async initiliaze(id){
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Purchase/getPurchase/' + id,
      headers: { },
      data : ''
    };
    var instance  = this;
    axios(config).then(function (response) {
      //console.table(response.data);
      instance.purchase = response.data;
      console.log(response.data)
    })
    .catch(function (error) {
      console.log(error);
    });

  }
}
