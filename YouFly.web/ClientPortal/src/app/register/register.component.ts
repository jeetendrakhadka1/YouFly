import { Component, OnInit } from '@angular/core';
import {User} from '../User';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {registerService } from  '../Services/register.service';
import {FormBuilder, ReactiveFormsModule, Validators, FormGroup} from "@angular/forms"
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  public user = new User('','','',);
  public errorMsg = '';
    
   
  constructor(private service: registerService, private router: Router, private route: ActivatedRoute) {}
          

  register(){
    console.log(this.user);
      this.service.register(this.user)
        .subscribe(
         res=>{     
            this.router.navigate(['login']);            
          },
          onerror => {
            this.errorMsg="Registration failed. Please try unique Username, Email";
          });
   console.log(Response);
  }

  

}



