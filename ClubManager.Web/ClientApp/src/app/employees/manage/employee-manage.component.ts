import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, DatePipe } from '@angular/common';
import { CustomValidators } from 'ngx-custom-validators';
import { EmployeeService } from '../employeeService';
import { AlertService } from '../../core/services/alert.service';
@Component({
  selector: 'employee-manage',
  templateUrl: './employee-manage.component.html'
})

export class EmployeeManageComponent {

  employeeForm: FormGroup;
  title: string = "";

  isBusy: boolean = false;
  submitted: boolean = false;
  isUpdate: boolean = false;

  employee: any;

  employeeTypes: any[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private _location: Location,
    private service: EmployeeService,
    private alertService: AlertService) {

    this.activatedRoute.data.subscribe((res: any) => {
      if (res.EmployeeManageResolver[1]) {
        this.title = "Ažuriranje zaposlenika";
        this.isUpdate = true;
        this.employeeTypes = res.EmployeeManageResolver[0];
        this.employee = res.EmployeeManageResolver[1].entity;
      }
      else {
        this.title = "Novi zaposlenik/ca";
      }

      this.employeeTypes = res.EmployeeManageResolver[0];

    });
  };

  ngOnInit(): void {
    this.configureForm();
  }

  configureForm() {
    if (!this.isUpdate) {
      this.employeeForm = this.formBuilder.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        type: [null]
      });
    }
    else {
      this.employeeForm = this.formBuilder.group({
        firstName: [this.employee.firstName, Validators.required],
        lastName: [this.employee.lastName, Validators.required],
        type: [this.employee.type]
      });
    }
  }

  changeType(e) {

  }

  onSubmit() {
    this.submitted = true;

    if (this.employeeForm.valid) {
      this.isBusy = true;

      var model = Object.assign({}, this.employeeForm.value);
      model.statusId = 4;

      if (this.isUpdate) {
        model.id = this.employee.id;
        this.updateEmployee(model);
      }
      else {
        this.createEmployee(model);
      }
    }
  }

  createEmployee(model: any) {
    this.service.createEmployee({
      firstName: model.firstName,
      lastName: model.lastName,
      type: model.type
    })
      .subscribe(
        (response) => {
          this.alertService.alertSaveSuccess();
          this.isBusy = false;

          this.router.navigate(['employees', response, 'profile'])
        },
        () => {
          this.alertService.alertSaveError();
          this.isBusy = false;
        }
      );
  }

  updateEmployee(model: any) {
    this.service.updateEmployee({
      id: this.employee.id,
      firstName: model.firstName,
      lastName: model.lastName
    })
      .subscribe(
        (response) => {
          this.alertService.alertSaveSuccess();
          this.isBusy = false;

          this.router.navigate(['employees', this.employee.id, 'profile'])
        },
        () => {
          this.alertService.alertSaveError();
          this.isBusy = false;
        }
      );
  }


  onBack() {
    this._location.back();
  }

}
