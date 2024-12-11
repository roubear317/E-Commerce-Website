import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { MediaComponent } from './Component/media/media.component';
import { AboutUsComponent } from './Component/about-us/about-us.component';
import { FAQSComponent } from './Component/faqs/faqs.component';
import { CartComponent } from './Component/cart/cart.component';
import { ProductDetailsComponent } from './Component/product-details/product-details.component';
import { ProductComponent } from './Component/product/product.component';
import { ContactUsComponent } from './Component/contact-us/contact-us.component';
import { ProductsByCategoryComponent } from './Component/products-by-category/products-by-category.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"Media",component:MediaComponent},
  {path:"AboutUs",component:AboutUsComponent},
  {path:"FAQS",component:FAQSComponent},
  {path:"Cart",component:CartComponent},
  {path:"ContactUS",component:ContactUsComponent},
  {path:"Products/:id",component:ProductDetailsComponent},
  {path:"Products",component:ProductComponent},
  {path:"Category/:Name",component:ProductsByCategoryComponent},
  {path:"Cart",component:CartComponent},
{path:"**",redirectTo:"",pathMatch:"full"}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
