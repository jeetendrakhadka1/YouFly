// import { Component, OnInit } from '@angular/core';
// import {searchBarService } from  '../Services/searchBar.service';
// import '../Airport';


// @Component({
//   selector: 'app-search-bar',
//   templateUrl: './search-bar.component.html',
//   //styleUrls: ['./search-bar.component.css']
// })
// export class searchBarComponent  {
//   constructor(private searchbarservice: searchBarService) { }

//   cityName : string;
//   airports: Airport[];
//   errorMessage: string;

//   grabCity(){
//     console.log("input :" + this.cityName);
//     this.searchbarservice.getAirports(this.cityName)
//       .subscribe(
//             airports => this.airports = airports,
//             error => this.errorMessage = <any>error
          
//             );  

//     }    
      
//   }
