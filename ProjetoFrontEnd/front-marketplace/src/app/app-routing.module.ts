import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WishlistDetailComponent } from './wishlist-detail/wishlist-detail.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { StoreRegisterComponent } from './store-register/store-register.component';
import { ProfileComponent } from './profile/profile.component';
import { PurchaseDetailsComponent } from './purchase-details/purchase-details.component';
import { SalesDetaisComponent } from './sales-detais/sales-detais.component';
import { PurchaseDetailComponent } from './purchase-detail/purchase-detail.component';
import { OwnerRegisterComponent } from './owner-register/owner-register.component';
import { ProductRegisterComponent } from './product-register/product-register.component';
const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'wishlist-detail',component:WishlistDetailComponent},
  {path:'client-register',component:ClientRegisterComponent},
  {path:'store-register',component:StoreRegisterComponent},
  {path:'profile',component:ProfileComponent},
  {path:'purchase-details',component:PurchaseDetailsComponent},
  {path:'sales-details',component:SalesDetaisComponent},
  {path:'owner-register', component:OwnerRegisterComponent},
  {path:'product-register', component:ProductRegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
