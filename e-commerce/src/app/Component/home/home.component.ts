import { Component, Input, OnInit } from '@angular/core';
import { ProductServiceService } from '../../Service/product-service.service';
import { IProduct } from '../../Models/Products';
import { initFlowbite } from 'flowbite';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  //@Input() searchQuery: string = '';
  products: IProduct[] = [];
  //filteredProducts: any[] = [];
  selectedCategoryProducts: IProduct[] = []; 
  ngOnInit():void {
    initFlowbite();
   }
  constructor(private services: ProductServiceService) {}

  GetSpecificCategory(event: any) {
    let CategoryName: string = event.target.value;
    this.services.GetproductByCategory(CategoryName).subscribe(
      (res: any) => {
        this.selectedCategoryProducts = res; 
      },
      (error) => {
        console.error(error.message);
      }
    );
  }

  searchProducts(searchTerm: string): void {
    if (!searchTerm) {
      this.selectedCategoryProducts = this.products;
      return;
    }

    this.selectedCategoryProducts = this.products.filter(product =>
      product.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

// constructor(private services:ProductServiceService){}


// GetSpecificCategory(event:any){
//   let CategoryName :string = ( event.target).value
// this.services.GetproductByCategory(CategoryName)
// console.log(event.target.value);

// }



// filterProducts() {
//   if (this.searchQuery) {
//     this.filteredProducts = this.products.filter(product =>
//       product.name.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
//       product.description.toLowerCase().includes(this.searchQuery.toLowerCase())
//     );
//   } else {
//     this.filteredProducts = this.products;  
//   }
// }














}
