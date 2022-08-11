import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { EmployeeOverviewComponent } from "./employee-overview.component";

const routes: Routes = [
  { path: 'overview', component: EmployeeOverviewComponent },
  //{
  //  path: 'profile/:id',
  //  component: AdminProductProfileComponent,
  //  resolve: { ProfileProductResolver }
  //},
  //{ path: 'create', component: AdminProductManageComponent, resolve: { AdminProductManageResolver } },
  //{ path: 'update/:id', component: AdminProductManageComponent, resolve: { AdminProductManageResolver } },
];

@NgModule({
  declarations: [
    EmployeeOverviewComponent
  ],
  imports: [
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
