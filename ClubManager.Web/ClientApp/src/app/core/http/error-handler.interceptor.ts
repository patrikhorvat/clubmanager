import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Logger } from '../services/logger.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';


const log = new Logger('ErrorHandlerInterceptor');

/**
 * Adds a default error handler to all requests.
 */
@Injectable()
export class ErrorHandlerInterceptor implements HttpInterceptor {

	/**
	 *
	 */
	constructor(private router: Router) {
	}

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(catchError(error => this.errorHandler(error)));
	}

	// Customize the default error handler here if needed
	private errorHandler(response: HttpEvent<any>): Observable<HttpEvent<any>> {
		if (response instanceof HttpErrorResponse) {
			if (response.status == 401) {
				var url = window.location.pathname;

				if (url.startsWith('/clients')) 
					this.router.navigateByUrl('/auth/clients');

				else if (url.startsWith('/partners'))
					this.router.navigateByUrl('/auth/partners');

				else if (url.startsWith('/admin'))
					this.router.navigateByUrl('/auth/admin');
					
				else
					this.router.navigateByUrl('/auth/clients');
			}
			else if (response.status == 403) {
				this.router.navigate(['forbidden']);
			}
		}

		throw response;
	}

}