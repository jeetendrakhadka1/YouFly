import { Component, OnInit } from '@angular/core';
import {FlightSearchService } from  '../Services/flight-search.service';
import { Flight } from '../flight';
import {MaterializeAction} from 'angular2-materialize';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css'],
  providers: [FlightSearchService]
})
export class FlightComponent implements OnInit {

  constructor(private flightService: FlightSearchService) { }

  flightSource: string;
  flightDestination: string;
  flights: Flight[];
  errorMessage: string;
  flight: Flight;

  searchFlights() {
    this.flightService.getFlightRoutes(this.flightSource, this.flightDestination)
            .subscribe(
              flights => this.flights = flights,
              error => this.errorMessage = <any>error
            );
  }  
  
  ngOnInit() {
  }

  purchaseTickets(flight) {
    console.log(flight);
    
  }

}
