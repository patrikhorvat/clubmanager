import { APP_INITIALIZER, NgModule, Optional, SkipSelf } from '@angular/core';

import { SettingsService } from './settings/settings.service';
import { ThemesService } from './themes/themes.service';
import { TranslatorService } from './translator/translator.service';
import { MenuService } from './menu/menu.service';

import { throwIfAlreadyLoaded } from './module-import-guard';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { HttpService } from './http/http.service';
import { HttpTokenInterceptor } from './http/http.token.interceptor';
import { ApiPrefixInterceptor } from './http/api-prefix.interceptor';
import { JwtService } from './http/jwt.service';
import { ApiService } from './http/api.service';
import { UserService } from './services/user.service';
import { HttpCacheService } from './http/http-cache.service';
import { ErrorHandlerInterceptor } from './http/error-handler.interceptor';
import { CacheInterceptor } from './http/cache.interceptor';
import { AuthGuard } from './services/auth-guard.service';

export function jwtTokenGetter() {
	return localStorage.getItem('jwtToken');
}

@NgModule({
    imports: [
        HttpClientModule,
		JwtModule.forRoot({
			config: {
				tokenGetter: jwtTokenGetter
			}
		})
    ],
    providers: [
        SettingsService,
        ThemesService,
        TranslatorService,
        MenuService,
        ApiPrefixInterceptor,
        JwtService,
        ApiService,
        UserService,
        HttpCacheService,
        ApiPrefixInterceptor,
        ErrorHandlerInterceptor,
        CacheInterceptor,
        AuthGuard,
        JwtHelperService,
        {
			provide: HttpClient,
			useClass: HttpService
		},
		{ 
			provide: HTTP_INTERCEPTORS, 
			useClass: HttpTokenInterceptor, 
			multi: true 
		}
    ],
    declarations: [
    ],
    exports: [
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}
