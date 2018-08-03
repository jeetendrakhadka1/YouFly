import { Component, OnInit, OnDestroy } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {loginService } from  '../Services/login.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Flight } from '../Flight';
import { FlightSearchService } from '../Services/flight-search.service';
import { Transaction } from '../Transaction';
import {FormBuilder, ReactiveFormsModule, Validators, FormGroup} from "@angular/forms"
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css'],
  providers: [FlightSearchService]
})
export class PurchaseComponent implements OnInit {

  currentUser: IUser;
  checkUser: boolean = false;
  checkRole: boolean;
  flightId: number;
  myflight: Flight;
  userId: number;
  public transaction = new Transaction(0, 0, 0, 0, 0, 0, 0, 0);
  private sub: any;
  errorMessage: string;

  constructor(private loginService: loginService, private router: Router, private flightSearch: FlightSearchService, private route: ActivatedRoute){
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    console.log(this.currentUser.id); 
    if(this.currentUser != null){
      console.log(this.currentUser.role);
        this.checkUser = true;
        if(this.currentUser.role == "admin"){
          console.log("admin is logging in");
            this.checkRole = true;
        }
    } 

  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {this.flightId = +params['flightId']});
    
    this.getFlight();
    console.log(this.currentUser);
    this.transaction.flightid = this.flightId;
    this.transaction.userid = this.currentUser.id;
  }

  getFlight() {
    this.flightSearch.getFlight(this.flightId)
                     .subscribe(
                       flight => this.myflight = flight,                       
                       error =>  this.errorMessage = <any>error);
                      
        console.log("test");
  }

  placeOrder() {
    this.flightSearch.placeTicketOrder(this.transaction)
                      .subscribe(
                        transaction => this.transaction = transaction,
                        error => this.errorMessage = <any>error);
        console.log(this.transaction);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
