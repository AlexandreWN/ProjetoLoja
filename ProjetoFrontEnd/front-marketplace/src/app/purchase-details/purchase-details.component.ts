import { Component, OnInit } from '@angular/core';
import { Purchase } from '../purchases';
import axios from "axios";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-purchase-details',
  templateUrl: './purchase-details.component.html',
  styleUrls: ['./purchase-details.component.css']
})
export class PurchaseDetailsComponent implements OnInit {
  titlePage = "Purchases"
  purchases : [Purchase] | undefined;
  constructor(private route: ActivatedRoute) { }

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
      url: 'http://localhost:5141/Purchase/getClient/'+ document,
      headers: {'Authorization': 'Bearer ' +token },
      data : ''
    };
    
    var instance  = this;
    axios(config).then(function (response) {
      instance.purchases = response.data;
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
    
  }
  
}
