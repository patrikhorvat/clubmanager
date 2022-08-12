import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { EmployeeOverviewComponent } from "./employee-overview.component";

const routes: Routes = [
  { path: 'overview', component: EmployeeOverviewComponent }
];

@NgModule({
  declarations: [
    EmployeeOverviewComponent
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
