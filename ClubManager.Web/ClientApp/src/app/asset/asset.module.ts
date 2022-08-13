import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AssetOverviewComponent } from "./asset-overview.component";

const routes: Routes = [
  {
    path: 'overview', component: AssetOverviewComponent
  }
];

@NgModule({
  declarations: [
    AssetOverviewComponent,
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
