import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http'
import {User} from '../User';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class loginService {
 public headers: Headers;
  constructor(private http: Http) { 
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json')

  }

  //mode = 'Observable';
  user: User;
   logIn(user){
    //let headers = new Headers({ 'Content-Type': 'application/json' });
    //let options = new RequestOptions({ headers: headers });
    let body = JSON.stringify(user);
    //console.log("1" + userName + "2" + Email + "3" + Password);
    return this.http.post('http://localhost:54413/api/Users/LogIn', body, {headers: this.headers})
    .map((res: Response) => {
      let receivedUser = <IUser>res.json();
      console.log(receivedUser);
      console.log(receivedUser.userName);
      if(receivedUser!= null){
        localStorage.setItem('currentUser', JSON.stringify(receivedUser))       
      }
    
  });
 }
 logout(){
   localStorage.removeItem('currentUser');
 }
}