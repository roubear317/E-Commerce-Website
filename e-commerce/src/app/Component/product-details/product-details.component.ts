import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../../Models/Products';
import { ProductServiceService } from './../../Service/product-service.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;
  mainImageUrl: string = '';

constructor(private service:ProductServiceService,private route :ActivatedRoute){}
// ngOnInit(): void {
//   const id = Number(this.route.snapshot.paramMap.get('id'));
//   if (id) {
//   this.GetOneProduct(this.product?.id);
//   }
// //this.GetSpecificCategory(n);

// }
ngOnInit(): void {
  const id = Number(this.route.snapshot.paramMap.get('id'));
  if (id) {
    this.GetOneProduct(id);
  } else {
    console.error('Invalid product ID');
  }

this.changeImage(this.product.photo[1].url);


}

GetOneProduct(id : number){

this.service.GetProductById(id).subscribe((res:IProduct)=>{
  console.log('API Response:', res);
this.product= res
console.log(this.product);
this.mainImageUrl = this.product.photo[0].url; // Initialize the main image URL

},(error)=>{console.log(error.message);
})
}

changeImage(newImageUrl: string): void {
  this.mainImageUrl = newImageUrl;
  console.log('Changing image to: ', newImageUrl);
}











}
