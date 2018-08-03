import '../Airport';
import { Flight } from '../flight';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers } from '@angular/http';
import { Request, RequestOptions } from '@angular/http'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class searchBarService {
 
  constructor(private http: Http) { }

  mode = 'Observable';
  airport: Airport;
  flight: Flight[];
  url = 'http://localhost:54413/api/';
 
 getAirports(name: string): Observable<Airport[]> {
    
    return this.http.get(this.url + 'Airports/city/' + name)
    .map(this.extractData).catch(this.handleError); 
   
  }

  getFlights(start: string, end: string): Observable<Flight[]> {
    return this.http.get(this.url + start )
    .map(this.extractData).catch(this.handleError); 
  }

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