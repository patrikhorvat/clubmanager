import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CoachesOverviewComponent } from "./coaches/coaches-overview.component";
import { EmployeeOverviewComponent } from "./employee-overview.component";
import { PlayersOverviewComponent } from "./players/players-overview.component";
import { EmployeeProfileComponent } from "./profile/employee-profile.component";
import { EmployeeProfileGeneralComponent } from "./profile/general/employee-profile-general.component";

const routes: Routes = [
  {
    path: 'overview', component: EmployeeOverviewComponent
  },
  {
    path: 'players', component: PlayersOverviewComponent
  },
  {
    path: 'coaches', component: CoachesOverviewComponent
  },
  {
    path: ':id/profile',
    component: EmployeeProfileComponent,
    resolve: { },
    runGuardsAndResolvers: 'always'
  },
];

@NgModule({
  declarations: [
    EmployeeOverviewComponent,
    EmployeeProfileComponent,
    EmployeeProfileGeneralComponent,
    PlayersOverviewComponent,
    CoachesOverviewComponent
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
export class EmployeesModule {

}
