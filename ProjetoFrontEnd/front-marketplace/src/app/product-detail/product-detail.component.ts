import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product,products } from '../products';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlePage = "Product Detail"
  product : Product | undefined
  
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;

    const prodictIdFromRoute = Number(routeParams.get('productId'));
    this.product = products.find(product => product.id===prodictIdFromRoute);
  }

}
