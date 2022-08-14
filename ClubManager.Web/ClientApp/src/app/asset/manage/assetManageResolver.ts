import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { forkJoin } from 'rxjs';
import { AssetService } from "../assetService";


@Injectable()
export class AssetManageResolver implements Resolve<any> {

  tempId: number = 0;

  constructor(private service: AssetService) {
  }

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    this.tempId = Number(route.paramMap.get('id'));
    if (route.paramMap.get('id')) {
      return forkJoin([
        this.service.getAssetTypes(),
        this.service.get(this.tempId)
      ]);
    } else {
      return forkJoin([
        this.service.getAssetTypes()
      ]);
    }
  };
}
