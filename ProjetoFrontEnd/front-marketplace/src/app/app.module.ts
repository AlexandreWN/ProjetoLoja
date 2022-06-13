import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { RouterModule } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { LoginComponent } from './login/login.component';
import { WishlistDetailComponent } from './wishlist-detail/wishlist-detail.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { StoreRegisterComponent } from './store-register/store-register.component';
import { ProfileComponent } from './profile/profile.component';
import { PurchaseDetailsComponent } from './purchase-details/purchase-details.component';
import { SalesDetaisComponent } from './sales-detais/sales-detais.component';
import { PurchaseDetailComponent } from './purchase-detail/purchase-detail.component';
import { MakePurchaseComponent } from './make-purchase/make-purchase.component';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductsListComponent,
    ProductDetailComponent,
    LoginComponent,
    WishlistDetailComponent,
    ClientRegisterComponent,
    StoreRegisterComponent,
    ProfileComponent,
    PurchaseDetailsComponent,
    SalesDetaisComponent,
    PurchaseDetailComponent,
    MakePurchaseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path:'',component:ProductsListComponent},
      {path: 'product/:productId', component: ProductDetailComponent},
      {path:'wishlist/:userId',component:WishlistDetailComponent},
      {path: 'purchase-detail/:purchaseId', component: PurchaseDetailComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
