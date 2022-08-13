import { Component } from "@angular/core";
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { ApiService } from "../../core/http/api.service";

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html'
})
export class EmployeeProfileComponent {

  employee: any = {};

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private apiService: ApiService) {

    this.apiService.get("/employee/" + this.activatedRoute.snapshot.params['id']).subscribe(x => {
      this.employee = x.entity;
    }, error => {
      this.employee = null;
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
