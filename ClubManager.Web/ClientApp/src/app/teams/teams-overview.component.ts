import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AlertModule } from "ngx-bootstrap/alert";
import { ApiService } from "../core/http/api.service";

@Component({
  selector: "app-teams-overview",
  templateUrl: "./teams-overview.component.html",
  providers: []
})

export class TeamOverviewComponent implements OnInit {

  teams: any;

  constructor(
    private router: Router, private apiService: ApiService) {

    this.apiService.post("/shared/overview/teams").subscribe(x => {
      this.teams = x.data;
    }, error => {
      this.teams = null;
    },
      () => {

      });

    this.refreshGrid();
  }

  refreshGrid() {

  }

  goToProfile(id) {
    this.router.navigate(['/team/' + id + '/profile']);
  }

  createteam() {

  }

  ngOnInit(): void {

  }

}
