import { Component } from "@angular/core";
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { ApiService } from "../../core/http/api.service";

@Component({
  selector: 'app-team-profile',
  templateUrl: './team-profile.component.html'
})
export class TeamProfileComponent {

  team: any = {};

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private apiService: ApiService) {

    this.apiService.get("/shared/team/" + this.activatedRoute.snapshot.params['id']).subscribe(x => {
      this.team = x.entity;
    }, error => {
      this.team = null;
    },
      () => {

      });

  }

  delete() {

  }

  update() {

  }

  rerunGuradsAndResolvers() {
    const defaultOnSameUrlNavigation = this.router.onSameUrlNavigation;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigateByUrl(this.router.url,
      {
        replaceUrl: true
      });
    this.router.onSameUrlNavigation = defaultOnSameUrlNavigation;
  }

}
