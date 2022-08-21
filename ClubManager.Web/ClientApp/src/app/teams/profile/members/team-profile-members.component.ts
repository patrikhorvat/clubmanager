import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AlertModule } from "ngx-bootstrap/alert";
import { ApiService } from "../../../core/http/api.service";
import { AlertService } from "../../../core/services/alert.service";
import { TeamService } from "../../teamService";

@Component({
  selector: "app-team-profile-members",
  templateUrl: "./team-profile-memebers.component.html",
  providers: []
})

export class TeamMembersOverviewComponent implements OnInit {

  members: any;

  @Input('team') team: any;

  constructor(
    private router: Router, private apiService: ApiService, private activatedRoute: ActivatedRoute,
    private alertService: AlertService,
    private service: TeamService) {

    this.apiService.post("/employee/overview/members/" + this.activatedRoute.snapshot.params['id']).subscribe(x => {
      this.members = x.data;
    }, error => {
      this.members = null;
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

  removeMember(id) {
    this.alertService.confirmDelete(this.service.remove(id)).subscribe(
      () => {
        this.refreshGrid();
      });
  }

  ngOnInit(): void {

  }

}
