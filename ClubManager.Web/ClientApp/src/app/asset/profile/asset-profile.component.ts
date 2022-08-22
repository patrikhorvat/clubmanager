import { Component } from "@angular/core";
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { ApiService } from "../../core/http/api.service";
import { AlertService } from "../../core/services/alert.service";
import { AssetService } from "../assetService";

@Component({
  selector: 'app-asset-profile',
  templateUrl: './asset-profile.component.html'
})
export class AssetProfileComponent {

  asset: any = {};

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private apiService: ApiService,
    private service: AssetService,
    private alertService: AlertService) {

    this.apiService.get("/asset/" + this.activatedRoute.snapshot.params['id']).subscribe(x => {
      this.asset = x.entity;
    }, error => {
      this.asset = null;
    },
      () => {

      });

  }

  deleteAsset() {
    this.alertService.confirmDelete(this.service.deleteAsset(this.activatedRoute.snapshot.params['id'])).subscribe(
      () => {
        this.router.navigate(['/asset/overview']);
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
