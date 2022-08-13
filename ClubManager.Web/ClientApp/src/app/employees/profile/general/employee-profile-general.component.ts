import { Component, Input } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-employee-profile-general',
  templateUrl: './employee-profile-general.component.html'
})
export class EmployeeProfileGeneralComponent {

  @Input('employee') employee: any;

  constructor(private activatedRoute: ActivatedRoute) {

  }
}
