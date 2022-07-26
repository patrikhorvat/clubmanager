import { Component, OnInit } from "@angular/core";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from "@angular/router";
import { UserService } from "../core/services/user.service";
import { TranslatorService } from "../core/translator/translator.service";

@Component({
    selector: 'app-notfound',
    templateUrl: './notfound.component.html',
    styleUrls: ['./notfound.component.scss']
})

export class NotFoundComponent implements OnInit {


	constructor(
		private jwtHelper: JwtHelperService, 
		private router: Router, 
		private userService: UserService,
		private translator: TranslatorService) {
		
	}

	ngOnInit(): void {
		this.translator.useLanguage("en");
	}

	redirectToApp(){
		var token = this.jwtHelper.tokenGetter();

		if(!token){
			this.router.navigate(['/auth/clients']);
		}
		else{
			var role = this.jwtHelper.decodeToken(token).role;

			switch (role){
				case "CLOUD_CLIENT": {
					this.router.navigate(['/clients']);
					break; 
				} 
				case "CLOUD_ADMIN": {				 
					this.router.navigate(['/admin']);
					break; 
				} 
				case "CLOUD_PARTNER": {				 
					this.router.navigate(['/partners']);
					break; 
				} 
				default: {
					this.router.navigate(['/clients']);
					break; 
				}
			}
		}
		
	}

	redirectToLogin(){
		this.userService.purgeAuth();
	}
	
}