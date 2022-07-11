import { Component, OnInit } from '@angular/core';
import { Sales } from '../sales';
import axios from 'axios';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
@Component({
  selector: 'app-sales-detais',
  templateUrl: './sales-detais.component.html',
  styleUrls: ['./sales-detais.component.css'],
})
export class SalesDetaisComponent implements OnInit {
  titlePage = 'Sales';
  purchases: [Sales] | undefined;
  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.initiliaze(Number(routeParams.get('userId')));
  }
  async initiliaze(id) {
    let token = localStorage.getItem('authToken');
    let document = localStorage.getItem('document');
    console.log(token);
    var config = {
      method: 'get',
      url: 'http://localhost:5141/Purchase/getOwner/' + document,
      headers: { Authorization: 'Bearer ' + token },
      data: '',
    };

    var instance = this;
    axios(config)
      .then(function (response) {
        instance.purchases = response.data;
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
