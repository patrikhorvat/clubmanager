import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthGuard implements CanActivate {

	constructor(private router: Router, private jwtHelper: JwtHelperService) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

		var token = this.jwtHelper.decodeToken(this.jwtHelper.tokenGetter());
		// Authenticated
		if(token){
			return true;
		}
		// Not authenticated
		else{
			this.router.navigate(['auth','login']);
			return false;
		}
	}
}