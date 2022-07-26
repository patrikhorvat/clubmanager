import { Component, OnInit } from "@angular/core";
import { UserService } from "../core/services/user.service";
import { Router } from "@angular/router";
import { JwtHelperService } from '@auth0/angular-jwt';
import { isArray } from "lodash";

@Component({
    selector: 'app-unauthorized',
    templateUrl: './unauthorized.component.html',
    styleUrls: ['./unauthorized.component.scss']
})

export class UnauthorizedComponent implements OnInit {	

	constructor(private jwtHelper: JwtHelperService, private router: Router, private userService: UserService) {
		
	}

	ngOnInit(): void {
		this.userService.populate();
	}
	

	redirectToApp() {
		var token = this.jwtHelper.tokenGetter();
	}

	redirectToLogin(){
		this.userService.purgeAuth();
	}
	
}