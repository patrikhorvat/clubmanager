import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AlertModule } from "ngx-bootstrap/alert";
import { ApiService } from "../../core/http/api.service";

export interface Employee {
  firstName: string;
  lastName: string;
  oib: number;
  statusName: string;
}

@Component({
  selector: "app-coaches-overview",
  templateUrl: "./coaches-overview.component.html",
  providers: []
})

export class CoachesOverviewComponent implements OnInit {

  employees: any;

  constructor(
    private router: Router, private apiService: ApiService) {

    this.apiService.post("/employee/overview/coaches").subscribe(x => {
      this.employees = x.data;
    }, error => {
      this.employees = null;
    },
      () => {

      });

    this.refreshGrid();
  }

  refreshGrid() {

  }

  goToProfile(id) {
    this.router.navigate(['/employees/' + id + '/profile']);
  }

  createEmployee() {

  }

  ngOnInit(): void {

  }

}
