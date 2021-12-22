import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductAdminComponent } from './product-admin/product-admin.component'
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component'

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'productadmin', component: ProductAdminComponent },
  { path: 'shoppingcart', component: ShoppingCartComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
