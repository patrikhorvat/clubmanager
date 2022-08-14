import { Component, Input } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-asset-profile-general',
  templateUrl: './asset-profile-general.component.html'
})
export class AssetProfileGeneralComponent {

  @Input('asset') asset: any;

  constructor(private activatedRoute: ActivatedRoute) {

  }
}
