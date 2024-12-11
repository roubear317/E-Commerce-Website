import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import AppComponent from './app.component';
import { CartComponent } from './Component/cart/cart.component';
import { Navbar1Component } from './Component/navbar1/navbar1.component';
import { Navbar2Component } from './Component/navbar2/navbar2.component';
import { ProductCardComponent } from './Component/product-card/product-card.component';
import { HomeComponent } from './Component/home/home.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './Component/product/product.component';
import { MainSliderComponent } from './Component/main-slider/main-slider.component';
import { SeconedSliderComponent } from './Component/seconed-slider/seconed-slider.component';
import { FooterComponent } from './Component/footer/footer.component';
import { ProductDetailsComponent } from './Component/product-details/product-details.component';
import { AboutUsComponent } from './Component/about-us/about-us.component';
import { FAQSComponent } from './Component/faqs/faqs.component';
import { ContactUsComponent } from './Component/contact-us/contact-us.component';
import { MediaComponent } from './Component/media/media.component';
import { ProductsByCategoryComponent } from './Component/products-by-category/products-by-category.component';
import { NotFoundComponent } from './Component/not-found/not-found.component';
import { ServerErrorComponent } from './Component/server-error/server-error.component';
import { ErrorInterseptor } from './Interseptor/Error.Interseptor';

@NgModule({
  declarations: [
    AppComponent,
    CartComponent,
    Navbar1Component,
    Navbar2Component,
    ProductCardComponent,
    HomeComponent,
    ProductComponent,
    MainSliderComponent,
    SeconedSliderComponent,
    FooterComponent,
    ProductDetailsComponent,
    AboutUsComponent,
    FAQSComponent,
    ContactUsComponent,
    MediaComponent,
    ProductsByCategoryComponent,
    NotFoundComponent,
    ServerErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:ErrorInterseptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
