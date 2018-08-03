import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// import "materialize-css";
import { FlightSearchService } from  './Services/flight-search.service';
import { AppComponent } from './app.component';
import { FlightComponent } from './flight/flight.component';
import {registerService } from  './Services/register.service';
import {loginService } from  './Services/login.service';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule }   from '@angular/router';
import { TestRouteComponent } from './test-route.component';
import { AppstartComponent } from './appstart/appstart.component';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import { RegisteredComponent } from './registered/registered.component';
import { NavBarComponent } from './nav-bar/nav-bar.component'

import { MaterializeModule } from 'angular2-materialize';
import { PurchaseComponent } from './purchase/purchase.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    TestRouteComponent,
    AppstartComponent,
    RegisteredComponent,
    FlightComponent,
    NavBarComponent,
    PurchaseComponent,  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path:'appcomponent',
    //redirectTo: '/',
    component: AppComponent
  },
  {
    path: 'registered',
    component: RegisteredComponent
  },
  {
    path: 'appstart',
    component: AppstartComponent
  },
  {
    path: 'purchase/:flightId',
    component: PurchaseComponent
  }  

]),
  
    MaterializeModule
  ],
  providers: [FlightSearchService, registerService, loginService],
  bootstrap: [AppstartComponent] 
  
})
 
export class AppModule { }
