import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from 'rxjs/Observable';

const swal = require('sweetalert');

@Injectable()
export class AlertService {

  constructor(private translate: TranslateService) {

  }

  displaySuccessMessage(message: string, title: string) {
    if (title)
      swal(this.translate.instant(title), this.translate.instant(message), 'success');
    else
      swal(this.translate.instant(message), "", 'success');
  }

  displayErrorMessage(message: string, title: string) {
    swal({
      icon: 'error',
      title: this.translate.instant(title),
      text: this.translate.instant(message),
      className: 'swal-delete'
    });
  }

  alertSaveSuccess() {
    swal({
      title: this.translate.instant("Spremanje uspješno"),
      icon: 'success'
    });
  }

  alertSaveError() {
    swal({
      title: this.translate.instant("Greška servera"),
      icon: 'error'
    });
  }

  confirmDelete(deleteRequest: Observable<any>,): Observable<any> {
    return Observable.create((observer) => {
      swal({
        title: this.translate.instant("Jeste li sigurni da želite ukloniti ovu stavku"),
        icon: 'warning',
        buttons: {
          cancel: {
            text: this.translate.instant("Odustani"),
            value: null,
            visible: true,
            className: "",
            closeModal: true
          },
          confirm: {
            text: this.translate.instant("Da"),
            value: true,
            visible: true,
            className: "bg-danger",
            closeModal: true
          }
        }
      }).then((isConfirm) => {
        if (isConfirm) {
          deleteRequest.subscribe((data) => {
            swal(this.translate.instant("Obrisano"), this.translate.instant("Uspješno"), 'success').then(() => {
              observer.next();
            });
          }, (error) => {
            swal({
              title: this.translate.instant("Greška"),
              text: this.translate.instant(error),
              icon: 'error',
              className: 'swal-delete'
            }).then(() => {
              observer.error();
            });
          })
        }
      });
    })
  }

  confirmAction(confirmRequest: Observable<any>, title: string): Observable<any> {
    return Observable.create((observer) => {
      swal({
        title: this.translate.instant(title),
        icon: 'warning',
        buttons: {
          cancel: {
            text: this.translate.instant("Odustani"),
            value: null,
            visible: true,
            className: "",
            closeModal: true
          },
          confirm: {
            text: this.translate.instant("Da"),
            value: true,
            visible: true,
            className: "bg-warning",
            closeModal: true
          }
        }
      }).then((isConfirm) => {
        if (isConfirm) {
          confirmRequest.subscribe((data) => {
            observer.next();
          }, (error) => {
            swal({
              title: this.translate.instant("Greaška"),
              text: this.translate.instant(error),
              icon: 'error',
              className: 'swal-delete'
            }).then(() => {
              observer.error();
            });
          })
        }
      });
    })
  }

  confirmPurgeAll(deleteRequest: Observable<any>): Observable<any> {
    return Observable.create((observer: any) => {
      swal({
        title: this.translate.instant("Obriši sve"),
        icon: 'warning',
        buttons: {
          cancel: {
            text: this.translate.instant("Odustani"),
            value: null,
            visible: true,
            className: "",
            closeModal: true
          },
          confirm: {
            text: this.translate.instant("Da"),
            value: true,
            visible: true,
            className: "bg-danger",
            closeModal: true
          }
        }
      }).then((confirmed: boolean) => {
        if (confirmed) {
          deleteRequest.subscribe(
            (data) => {
              swal(this.translate.instant("Obrisano"), this.translate.instant("Uspješno"), 'success').then(() => {
                observer.next();
              });
            },
            (error) => {
              swal(this.translate.instant("Greška"), this.translate.instant(error) + '.', 'error').then(() => {
                observer.error();
              });
            })
        }
      });
    })
  }

}
