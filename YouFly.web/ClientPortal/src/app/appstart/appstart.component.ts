import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-appstart',
  templateUrl: './appstart.component.html',
  styleUrls: ['./appstart.component.css']
})
export class AppstartComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.router.navigate(['appcomponent']);
  }

}
