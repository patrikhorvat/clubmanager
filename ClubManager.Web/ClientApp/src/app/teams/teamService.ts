import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/core/http/api.service';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class TeamService {

  constructor(private apiService: ApiService) { }

  remove(id: number) {
    return this.apiService.delete("/shared/team/member/" + id);
  }
  addTeamMember(teamId: number, memberId: number) {
    return this.apiService.post("/shared/team/member/add/" + teamId + "/" + memberId);
  }

}

