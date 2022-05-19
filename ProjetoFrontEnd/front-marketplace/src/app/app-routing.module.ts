import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WishlistDetailComponent } from './wishlist-detail/wishlist-detail.component';
import { AddressRegisterComponent } from './address-register/address-register.component';

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'wishlist-detail',component:WishlistDetailComponent},
  {path:'address-register',component:AddressRegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
