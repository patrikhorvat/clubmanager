import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AlertModule } from "ngx-bootstrap/alert";
import { ApiService } from "../core/http/api.service";

@Component({
  selector: "app-asset-overview",
  templateUrl: "./asset-overview.component.html",
  providers: []
})

export class AssetOverviewComponent implements OnInit {

  assets: any;

  constructor(
    private router: Router, private apiService: ApiService) {

    this.apiService.post("/asset/overview").subscribe(x => {
      this.assets = x.data;
    }, error => {
      this.assets = null;
    },
      () => {

      });

    this.refreshGrid();
  }

  refreshGrid() {

  }

  goToProfile(id) {
    this.router.navigate(['/asset/' + id + '/profile']);
  }

  createAsset() {

  }

  ngOnInit(): void {

  }

}
