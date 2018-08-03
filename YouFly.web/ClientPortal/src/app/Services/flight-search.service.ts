import '../Airport';
import { Flight } from '../flight';
import { Transaction } from '../Transaction';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class FlightSearchService {

  constructor(private http: Http) { }
  
  mode = 'Observable';
  airport: Airport;
  flight: Flight[];
  url = 'http://localhost:54413/api/Flights/';

  getFlightRoutes(start: string, end: string): Observable<Flight[]> {
    return this.http.get(this.url + 'routes?startCity=' + start + '&endCity=' + end )
    .map(this.extractData).catch(this.handleError); 
  }

  getFlight(id: number): Observable<Flight> {
    return this.http.get(this.url + id )
    .map(this.extractData).catch(this.handleError); 
  }

  placeTicketOrder(transaction: Transaction): Observable<Transaction>{
    let body = transaction;
    console.log(transaction);
    return this.http.post('http://localhost:54413/api/Transactions/placeOrder', body)
        .map((res: Response) => res.json());
  };

//   register(user): Observable<User>{
//     //let headers = new Headers({ 'Content-Type': 'x-www-form-urlencoded' });
//     //let options = new RequestOptions({ headers: headers });
//     let body = user;
//     //console.log("1" + userName + "2" + Email + "3" + Password);
//     return this.http.post('http://localhost:54413/api/Users/postUsers', body)
//     .map((res: Response) => res.json());
//  }

  private extractData(res: Response) {
     let body = res.json();
     console.log(body);
     return body || {};         
  }

  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    //console.error(errMsg);
    return Observable.throw(errMsg);
  }
}
