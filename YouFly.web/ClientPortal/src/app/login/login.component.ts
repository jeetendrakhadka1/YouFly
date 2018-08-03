import { Component, OnInit } from '@angular/core';
import {User} from '../User';
import {loginService } from  '../Services/login.service';
import '../IUser.ts';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {
 public user = new User('dummy','','');
  public errorMsg = '';
customer: IUser;
returnUrl: String;
  
 constructor(private service: loginService, private router: Router, private route: ActivatedRoute) { }
  
  login(){
    this.errorMsg= '';
    console.log(this.user);
     this.service.logIn(this.user)
        .subscribe(
          res=>{     
            this.router.navigate(['appcomponent']);
            
          },
          onerror =>{
            this.errorMsg ="Username/Password combination does not match";
          }
          
          );
         
  }

  printUserName(){
    console.log(this.customer.userName);
  }

  

}
