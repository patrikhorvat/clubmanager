import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule } from "@angular/forms";
import { TeamOverviewComponent } from "./teams-overview.component";
import { TeamProfileComponent } from "./profile/team-profile.component";
import { TeamProfileGeneralComponent } from "./profile/general/team-profile-general.component";
import { TeamMembersOverviewComponent } from "./profile/members/team-profile-members.component";
import { TeamService } from "./teamService";

const routes: Routes = [
  {
    path: 'overview', component: TeamOverviewComponent
  },
  {
    path: ':id/profile',
    component: TeamProfileComponent,
    resolve: {},
    runGuardsAndResolvers: 'always'
  }
];

@NgModule({
  declarations: [
    TeamOverviewComponent,
    TeamProfileComponent,
    TeamProfileGeneralComponent,
    TeamMembersOverviewComponent
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
    TeamService
  ],
  entryComponents: [

  ]
})
export class TeamsModule {

}
