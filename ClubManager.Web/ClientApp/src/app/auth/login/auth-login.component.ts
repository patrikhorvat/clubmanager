import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CustomValidators } from 'ngx-custom-validators';
import { MenuService } from 'src/app/core/menu/menu.service';
import { Credentials } from 'src/app/core/models/credentials.interface';
import { UserService } from 'src/app/core/services/user.service';
import { SettingsService } from 'src/app/core/settings/settings.service';
import { TranslatorService } from 'src/app/core/translator/translator.service';

@Component({
    selector: 'auth-login-component',
    templateUrl: './auth-login.component.html'
})
export class AuthLoginComponent implements OnInit {

    isBusy: boolean = false;
    credentials: Credentials = { email: '', password: '' };

	public alerts: Array<{ message: string }> = [];

    inputType: string = 'password';
    eyeIcon: string = 'fa fa-eye';
    returnUrl: string = '';

    constructor(
        private activeRoute: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private translator: TranslatorService,
        public settingsService: SettingsService,
		private translate: TranslateService,
		public menuService: MenuService
        ) {

        }

    ngOnInit() {
        this.returnUrl = this.activeRoute.snapshot.queryParams['returnUrl'];
    }

    login( form:NgForm) {
        if(form.valid){
            let value = form.value;
            this.isBusy = true;
            this.userService.attemptAuth(value.email, value.password)
                .subscribe(user=>{
                    debugger;
                    this.router.navigate(['/home']);
                },
                error=>{
                    debugger;
                    this.alerts = [];

                    if (error instanceof ProgressEvent) {
                        this.alerts.push({ message: 'forms.login.error.appunavailable' });
                    }
                    else {
                        this.alerts.push({ message: 'forms.login.error.wronguserpassword' });
                    }

                    this.isBusy = false;
                });
        }
    }

    changeType(){
        if(this.inputType == 'password'){
            this.inputType = 'text';
            this.eyeIcon = 'fa fa-eye-slash';
        }
        else{
            this.inputType = 'password'
            this.eyeIcon = 'fa fa-eye';
        }
    }
}
