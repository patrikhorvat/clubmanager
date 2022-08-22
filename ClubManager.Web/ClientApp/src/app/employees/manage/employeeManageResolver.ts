import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { forkJoin } from 'rxjs';
import { EmployeeService } from "../employeeService";

@Injectable()
export class EmployeeManageResolver implements Resolve<any> {

  tempId: number = 0;

  constructor(private service: EmployeeService) {
  }

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    this.tempId = Number(route.paramMap.get('id'));
    if (route.paramMap.get('id')) {
      return forkJoin([
        this.service.getEmployeeTypes(),
        this.service.get(this.tempId)
      ]);
    } else {
      return forkJoin([
        this.service.getEmployeeTypes()
      ]);
    }
  };
}
