import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { EmployeeOverviewComponent } from "./employee-overview.component";
import { EmployeeProfileComponent } from "./profile/employee-profile.component";
import { EmployeeProfileGeneralComponent } from "./profile/general/employee-profile-general.component";

const routes: Routes = [
  {
    path: 'overview', component: EmployeeOverviewComponent
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
    EmployeeProfileGeneralComponent
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
