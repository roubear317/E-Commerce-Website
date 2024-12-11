import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from '../Models/Products';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {


  private baseUrl = "https://localhost:44398/api/Products";
  constructor(private http :HttpClient) { }

GetAllProduct(){
 

 return  this.http.get("https://localhost:44398/api/Products?sort=Name")
}

GetproductByCategory(Category:string){

  return this.http.get("https://localhost:44398/api/products/Category/"+Category)
}


GetProductById(id:number){
  return  this.http.get<IProduct>("https://localhost:44398/api/Products/"+id)

}

}

