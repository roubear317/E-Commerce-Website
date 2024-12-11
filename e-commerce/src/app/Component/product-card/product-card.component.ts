import { Component, Input, OnInit } from '@angular/core';
import { ProductServiceService } from '../../Service/product-service.service';
import { IProduct } from '../../Models/Products';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css'
})
export class ProductCardComponent implements OnInit {
  @Input() products :IProduct[] =[]

  //@Input() product: any;
constructor(private services:ProductServiceService){}

ngOnInit(): void {
  this.GetAllProductPutInCard();

//this.GetSpecificCategory(n);

}
GetAllProductPutInCard(){
 this.services.GetAllProduct().subscribe((res:any)=>{
this.products=res


 },error =>{

  alert(error.message)
 }


)
}

GetSpecificCategory(event : any){
  let CategoryName :string = event.target
this.services.GetproductByCategory(CategoryName).subscribe((res:any)=>{


  this.products=res
},error=>{console.log(error.message)}
 )

}


getFirstThreeWords(text: string): string {
  return text.split(' ').slice(0, 3).join(' ');
}



// searchProducts(searchTerm: string): void {
//   if (!searchTerm) {
//     this.GetAllProductPutInCard();
//     return;
//   }

//   this.products = this.products.filter(product =>
//     product.name.toLowerCase().includes(searchTerm.toLowerCase())
//   );
// }






}
