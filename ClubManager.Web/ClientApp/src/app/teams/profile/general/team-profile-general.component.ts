import { Component, Input } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-team-profile-general',
  templateUrl: './team-profile-general.component.html'
})
export class TeamProfileGeneralComponent {

  @Input('team') team: any;

  constructor(private activatedRoute: ActivatedRoute) {
   
  }
}
