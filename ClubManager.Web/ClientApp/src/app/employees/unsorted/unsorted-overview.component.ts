import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AlertModule } from "ngx-bootstrap/alert";
import { ApiService } from "../../core/http/api.service";
import { AlertService } from "../../core/services/alert.service";
import { TeamService } from "../../teams/teamService";

export interface Employee {
  firstName: string;
  lastName: string;
  oib: number;
  statusName: string;
}

@Component({
  selector: "app-unsorted-overview",
  templateUrl: "./unsorted-overview.component.html",
  providers: []
})

export class UnsortedOverviewComponent implements OnInit {

  employees: any;

  constructor(
    private router: Router,
    private apiService: ApiService,
    private alertService: AlertService,
    private activatedRoute: ActivatedRoute,
    private service: TeamService
  ) {

    this.apiService.post("/employee/overview/members/unsorted").subscribe(x => {
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

  linkToTeam(memberId) {
    this.alertService.confirmAction(this.service.addTeamMember(this.activatedRoute.snapshot.params['id'], memberId),
      "Jeste li sigurni da želite dodati novog člana u tim?").subscribe(
      () => {
          this.router.navigate(['/team/' + this.activatedRoute.snapshot.params['id'] + '/profile']);
      });
  }

  createEmployee() {

  }

  ngOnInit(): void {

  }

}
