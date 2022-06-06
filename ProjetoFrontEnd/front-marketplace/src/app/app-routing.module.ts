import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WishlistDetailComponent } from './wishlist-detail/wishlist-detail.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { StoreRegisterComponent } from './store-register/store-register.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'wishlist-detail',component:WishlistDetailComponent},
  {path:'client-register',component:ClientRegisterComponent},
  {path:'store-register',component:StoreRegisterComponent},
  {path:'profile',component:ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
