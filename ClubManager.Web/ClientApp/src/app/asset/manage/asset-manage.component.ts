import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, DatePipe } from '@angular/common';
import { CustomValidators } from 'ngx-custom-validators';
import { AssetService } from '../assetService';
@Component({
  selector: 'asset-manage',
  templateUrl: './asset-manage.component.html'
})

export class AssetManageComponent {

  assetForm: FormGroup;
  title: string = "";

  isBusy: boolean = false;
  submitted: boolean = false;
  isUpdate: boolean = false;

  asset: any;

  assetTypes: any[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private _location: Location,
    private service: AssetService) {

    this.activatedRoute.data.subscribe((res: any) => {
      if (res.AssetManageResolver[1]) {
        this.title = "Ažuriranje imovine";
        this.isUpdate = true;
        this.asset = res.AssetManageResolver[1].entity;
      }
      else {
        this.title = "Nova imovina";
      }

      this.assetTypes = res.AssetManageResolver[0];

    });
  };


  ngOnInit(): void {
    this.configureForm();
  }

  configureForm() {
    if (!this.isUpdate) {
      this.assetForm = this.formBuilder.group({
        name: [null, [Validators.required]],
        description: [null],
        condition: [null],
        type: [null, Validators.required]
      });
    }
    else {
      this.assetForm = this.formBuilder.group({
        name: [this.asset.name, [Validators.required]],
        description: [this.asset.description],
        condition: [this.asset.condition],
        type: [this.asset.type, Validators.required]
      });
    }
  }

  onSubmit() {
    this.submitted = true;
    debugger;
    if (this.assetForm.valid) {
      this.isBusy = true;

      var model = Object.assign({}, this.assetForm.value);

      if (this.isUpdate) {
        this.updateAsset(model);
      }
      else {
        this.createAsset(model);
      }
    }
  }

  createAsset(model: any) {
    this.service.createAsset({
      name: model.name,
      description: model.description,
      type: model.type,
      condition: model.condition 
    })
      .subscribe(
        (response) => {
          //this.alertService.alertSaveSuccess();
          this.isBusy = false;

          this.router.navigate(['asset', response, 'profile'])
        },
        () => {
          //this.alertService.alertSaveError();
          this.isBusy = false;
        }
      );
  }

  updateAsset(model: any) {
    this.service.updateAsset({
      id: this.asset.id,
      name: model.name,
      description: model.description,
      type: model.type,
      condition: model.condition
    })
      .subscribe(
        (response) => {
          //this.alertService.alertSaveSuccess();
          this.isBusy = false;

          this.router.navigate(['admin', 'assets', this.asset.id, 'profile'])
        },
        () => {
          //this.alertService.alertSaveError();
          this.isBusy = false;
        }
      );
  }


  onBack() {
    this._location.back();
  }

}
