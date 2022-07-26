import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject, ReplaySubject } from 'rxjs';

import { map, distinctUntilChanged } from 'rxjs/operators';
import { JwtService } from '../http/jwt.service';
import { ApiService } from '../http/api.service';

import { User } from '../models/user.model';
import { SettingsService } from '../settings/settings.service';
import { Router } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class UserService {
	public currentUserSubject = new BehaviorSubject<User>({} as User);
	public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

	private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
	public isAuthenticated = this.isAuthenticatedSubject.asObservable();

	private userSettings: { [key: string] : string; } = {};

	constructor(
		private apiService: ApiService,
        private jwtService: JwtService,
        private jwtHelper: JwtHelperService,
		private settingsService: SettingsService,
		private router: Router
	) { }

	// Verify JWT in localstorage with server & load user's info.
	// This runs once on application startup.
	populate() {
		// If JWT detected, attempt to get & store user's info
		let token: string;
        if (token = this.jwtService.getToken()) {

            let decodedToken = this.jwtHelper.decodeToken(token);
            let userRoles: string[] = decodedToken.role;

			// this.apiService.get('/user/info')
			// 	.subscribe(
			// 		data => {
			// 			this.setAuth({
			// 				id: data.user.id,
			// 				firstName: data.user.firstName,
			// 				lastName: data.user.lastName,
			// 				displayName: data.user.displayName,
			// 				email: data.user.email,
			// 				userName: data.user.userName,
			// 				telephone: data.user.telephone,
			// 				mobilePhone: data.user.mobilePhone,
			// 				company: data.user.company,
			// 				companyId:data.user.companyId,
			// 				jobPosition: data.user.jobPosition,
			// 				culture: data.user.culture,
			// 				cultureLabel: data.user.cultureLabel,
			// 				language: data.user.language,
			// 				languageFlagClass: data.user.languageFlagClass,
			// 				languageLabel: data.user.languageLabel,
			// 				timeZone: data.user.timeZone,
			// 				timeZoneName: data.user.timeZoneName,
			// 				token: token,
            //                 userRoles: userRoles,
			// 				companyDomain: data.user.companyDomain,
			// 				countryName:data.user.countryName
			// 			});

						
			// 			this.setUserSettings(data.userSettings);

			// 		},
			// 		err => this.purgeAuth()
			// 	);
		} else {
			// Remove any potential remnants of previous auth states
			this.purgeAuth();
		}
	}

	setAuth(user: User) {
		// Save JWT sent from server in localstorage
		this.jwtService.saveToken("");
		// Set current user data into observable
		this.currentUserSubject.next(user);
		// Set isAuthenticated to true
		this.isAuthenticatedSubject.next(true);
	}

	purgeAuth() {
		// Remove JWT from localstorage
		this.jwtService.destroyToken();
		// Set current user to an empty object
		this.currentUserSubject.next({} as User);
		// Set auth status to false
		this.isAuthenticatedSubject.next(false);
	}

	attemptAuth(userName: string, password: string): Observable<User> {

		return this.apiService.post('/authenticate/login', { userName: userName, password: password })
			.pipe(map(
				data => {
					var token = data.token;
					this.jwtService.saveToken(token);
					this.isAuthenticatedSubject.next(true);
					return data;
				}
			));
	}

	updateJwtToken(){

	}

	getCurrentUser(): User {
		return this.currentUserSubject.value;

	}

	setUserSettings(settings) {
		settings.map(x => {
			this.userSettings[x.userSettingType.settingKey] = x.settingValue;
		});
	};
}
