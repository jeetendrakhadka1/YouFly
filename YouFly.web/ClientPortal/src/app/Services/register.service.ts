import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http'
import {User} from '../User';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class registerService {
 
  constructor(private http: Http) { }

  mode = 'Observable';
  user: User;
   register(user): Observable<User>{
    //let headers = new Headers({ 'Content-Type': 'x-www-form-urlencoded' });
    //let options = new RequestOptions({ headers: headers });
    let body = user;
    //console.log("1" + userName + "2" + Email + "3" + Password);
    return this.http.post('http://localhost:54413/api/Users/postUsers', body)
    .map((res: Response) => res.json());
 }
}