import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-employee-overview",
  templateUrl: "./employee-overview.component.html",
  providers: []
})

export class EmployeeOverviewComponent implements OnInit {

  employees: any;

  constructor(
    private router: Router) {

    this.refreshGrid();
  }

  refreshGrid() {

  }

  ngOnInit(): void {
 
  }

}
