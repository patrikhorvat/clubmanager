import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule } from "@angular/forms";
import { TeamOverviewComponent } from "./teams-overview.component";

const routes: Routes = [
  {
    path: 'overview', component: TeamOverviewComponent
  },
  //{
  //  path: ':id/profile',
  //  component: TeamProfileComponent,
  //  resolve: {},
  //  runGuardsAndResolvers: 'always'
  //}
];

@NgModule({
  declarations: [
    TeamOverviewComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
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
export class TeamsModule {

}
