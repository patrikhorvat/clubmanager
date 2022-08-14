import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AssetOverviewComponent } from "./asset-overview.component";
import { AssetService } from "./assetService";
import { AssetManageComponent } from "./manage/asset-manage.component";
import { AssetProfileComponent } from "./profile/asset-profile.component";
import { AssetProfileGeneralComponent } from "./profile/general/asset-profile-general.component";
import { AssetManageResolver } from "./manage/assetManageResolver";

const routes: Routes = [
  {
    path: 'overview', component: AssetOverviewComponent
  },
  {
    path: ':id/profile',
    component: AssetProfileComponent,
    resolve: {},
    runGuardsAndResolvers: 'always'
  },
  {
    path: 'create',
    pathMatch: 'full',
    component: AssetManageComponent,
    resolve: { AssetManageResolver }
  },
  {
    path: ':id/update',
    pathMatch: 'full',
    component: AssetManageComponent,
    resolve: { AssetManageResolver }
  }
];

@NgModule({
  declarations: [
    AssetOverviewComponent,
    AssetProfileComponent,
    AssetProfileGeneralComponent,
    AssetManageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
    AssetService,
    AssetManageResolver
  ],
  entryComponents: [

  ]
})
export class AssetModule {

}
