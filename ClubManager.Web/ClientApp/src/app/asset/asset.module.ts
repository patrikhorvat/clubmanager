import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AssetOverviewComponent } from "./asset-overview.component";
import { AssetProfileComponent } from "./profile/asset-profile.component";
import { AssetProfileGeneralComponent } from "./profile/general/asset-profile-general.component";

const routes: Routes = [
  {
    path: 'overview', component: AssetOverviewComponent
  },
  {
    path: ':id/profile',
    component: AssetProfileComponent,
    resolve: {},
    runGuardsAndResolvers: 'always'
  }
];

@NgModule({
  declarations: [
    AssetOverviewComponent,
    AssetProfileComponent,
    AssetProfileGeneralComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [

  ],
  entryComponents: [

  ]
})
export class AssetModule {

}
