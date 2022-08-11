import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../../core/http/api.service';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isBusy: boolean = false;

  employeesCount: number = 0;
  employeesPlayersCount: number = 0;
  employeesAdminsCount: number = 0;
  employeesLeadsCount: number = 0;
  employeesRestCount: number = 0;
  employeesCoachesCount: number = 0;
  employeesMaintenancesCount: number = 0;
  employeesPlayersInjuryCount: number = 0;

  assetCount: number = 0;
  assetBallCount: number = 0;
  assetBrokenCount: number = 0;
  assetGoalCount: number = 0;
  assetYerseyCount: number = 0;
  assetRestCount: number = 0;
  assetMachineCount: number = 0;
  assetSocksCount: number = 0;

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit()
  {
    this.isBusy = true;
    this.apiService.get("/dashboard/count-employees").subscribe(x => {
      this.employeesCount = x;
    }, error => {
      this.employeesCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-players").subscribe(x => {
      this.employeesPlayersCount = x;
    }, error => {
      this.employeesPlayersCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-injury").subscribe(x => {
      this.employeesPlayersInjuryCount = x;
    }, error => {
      this.employeesPlayersInjuryCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-admins").subscribe(x => {
      this.employeesAdminsCount = x;
    }, error => {
      this.employeesAdminsCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-lead").subscribe(x => {
      this.employeesLeadsCount = x;
    }, error => {
      this.employeesLeadsCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-rest").subscribe(x => {
      this.employeesRestCount = x;
    }, error => {
      this.employeesRestCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-coaches").subscribe(x => {
      this.employeesCoachesCount = x;
    }, error => {
      this.employeesCoachesCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-employees-maintenance").subscribe(x => {
      this.employeesMaintenancesCount = x;
    }, error => {
      this.employeesMaintenancesCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset").subscribe(x => {
      this.assetCount = x;
    }, error => {
      this.assetCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-ball").subscribe(x => {
      this.assetBallCount = x;
    }, error => {
      this.assetBallCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-socks").subscribe(x => {
      this.assetSocksCount = x;
    }, error => {
      this.assetSocksCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-yersey").subscribe(x => {
      this.assetYerseyCount = x;
    }, error => {
      this.assetYerseyCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-machine").subscribe(x => {
      this.assetMachineCount = x;
    }, error => {
      this.assetMachineCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-rest").subscribe(x => {
      this.assetRestCount = x;
    }, error => {
      this.assetRestCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-broken").subscribe(x => {
      this.assetBrokenCount = x;
    }, error => {
      this.assetBrokenCount = 0;
    },
      () => {
        this.isBusy = false;
      });

    this.apiService.get("/dashboard/count-asset-goal").subscribe(x => {
      this.assetGoalCount = x;
    }, error => {
      this.assetGoalCount = 0;
    },
      () => {
        this.isBusy = false;
      });

  }

  goToState = function () { };

}
