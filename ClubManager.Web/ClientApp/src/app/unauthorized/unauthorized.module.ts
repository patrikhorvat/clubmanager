import { NgModule } from "@angular/core";
import { UnauthorizedComponent } from "./unauthorized.component";
import { UnauthorizedRoutingModule } from "./unauthorized-routing.module";
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations: [
		UnauthorizedComponent
    ],
    imports: [
		UnauthorizedRoutingModule,
		HttpClientModule,		
        SharedModule
    ]
})

export class UnauthorizedModule {

 }
