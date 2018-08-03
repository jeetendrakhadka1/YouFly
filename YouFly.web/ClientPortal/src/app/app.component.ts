import { Component, OnInit} from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {loginService } from  './Services/login.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  title = 'YouFly';
  currentUser: IUser;
  checkUser: boolean = false;
  checkRole: boolean;
  constructor(private loginService: loginService, private router: Router, private route: ActivatedRoute){
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    console.log(this.currentUser);   
    if(this.currentUser != null){
      console.log(this.currentUser.role);
        this.checkUser = true;
        if(this.currentUser.role == "admin"){
          console.log("admin is logging in");
            this.checkRole = true;
        }
    }  
    // (window).$ = (window).jQuery;
  }

  logOut(): void{
    this.loginService.logout();
    this.router.navigate(['appstart']);
    

  }

  }  

