import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";
import { TeamService } from "../teams/teamService";
import { CoachesOverviewComponent } from "./coaches/coaches-overview.component";
import { EmployeeOverviewComponent } from "./employee-overview.component";
import { EmployeeService } from "./employeeService";
import { EmployeeManageComponent } from "./manage/employee-manage.component";
import { EmployeeManageResolver } from "./manage/employeeManageResolver";
import { PlayersOverviewComponent } from "./players/players-overview.component";
import { EmployeeProfileComponent } from "./profile/employee-profile.component";
import { EmployeeProfileGeneralComponent } from "./profile/general/employee-profile-general.component";
import { UnsortedOverviewComponent } from "./unsorted/unsorted-overview.component";

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
  {
    path: ':id/unsorted', component: UnsortedOverviewComponent
  },
  {
    path: 'create',
    pathMatch: 'full',
    component: EmployeeManageComponent,
    resolve: { EmployeeManageResolver }
  },
  {
    path: ':id/update',
    pathMatch: 'full',
    component: EmployeeManageComponent,
    resolve: { EmployeeManageResolver }
  }
];

@NgModule({
  declarations: [
    EmployeeOverviewComponent,
    EmployeeProfileComponent,
    EmployeeProfileGeneralComponent,
    PlayersOverviewComponent,
    CoachesOverviewComponent,
    UnsortedOverviewComponent,
    EmployeeManageComponent
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
    EmployeeService,
    EmployeeManageResolver,
    TeamService
  ],
  entryComponents: [
    
  ]
})
export class EmployeesModule {

}
