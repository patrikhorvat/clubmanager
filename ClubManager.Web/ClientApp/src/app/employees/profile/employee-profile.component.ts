import { Component } from "@angular/core";
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { ApiService } from "../../core/http/api.service";
import { AlertService } from "../../core/services/alert.service";
import { EmployeeService } from "../employeeService";

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html'
})
export class EmployeeProfileComponent {

  employee: any = {};

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private apiService: ApiService,
    private service: EmployeeService,
    private alertService: AlertService  ) {

    this.apiService.get("/employee/" + this.activatedRoute.snapshot.params['id']).subscribe(x => {
      this.employee = x.entity;
    }, error => {
      this.employee = null;
    },
      () => {

      });

  }

  deleteEmployee() {
    this.alertService.confirmDelete(this.service.deleteEmployee(this.activatedRoute.snapshot.params['id'])).subscribe(
      () => {
        this.router.navigate(['/employees/overview']);
      });
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
