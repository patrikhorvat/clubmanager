import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { AuthRoutingModule } from "./auth-routing";
import { AuthComponent } from "./auth.component";
import { SharedModule } from "../shared/shared.module";
import { AuthLoginComponent } from "./login/auth-login.component";


@NgModule({
    declarations: [
        AuthComponent,
        AuthLoginComponent
    ],
    imports: [
        FormsModule,
        SharedModule,
        AuthRoutingModule
    ],
    providers:[
    ]
})
export class AuthModule {

}