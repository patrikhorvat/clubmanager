import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { SettingsService } from '../settings/settings.service';


@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {

  constructor(private settings:SettingsService){}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!/^(http|https):/i.test(request.url)) {
      if(request.url.indexOf('assets/i18n') == -1 ){
      request = request.clone({ url: this.settings.getAppSetting('apiAddress') + request.url });
      }
    }
    return next.handle(request);
  }
}