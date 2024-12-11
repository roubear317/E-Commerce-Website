import { Component, OnInit } from '@angular/core';
import { initFlowbite } from 'flowbite';
import { Event, Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  //styleUrl: './app.component.css'
  styleUrls: ['./app.component.css']
})
export default class AppComponent implements OnInit {
  title = 'e-commerce';
  //searchQuery: string = '';

  ngOnInit():void {
  initFlowbite();
 }

 constructor(private router: Router) {}

//  handleSearch(query: Event) {
//    this.searchQuery = query.toString();
//    this.router.navigate([], {
//      queryParams: { searchQuery: query },
//      queryParamsHandling: 'merge', // لضمان إضافة المعاملات بدون مسح المعاملات السابقة
//    });
//  }

 
}
