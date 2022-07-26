import { NgModule } from "@angular/core";
import { NotFoundComponent } from "./notfound.component";
import { NotFoundRoutingModule } from "./notfound-routing.module";
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations: [
		NotFoundComponent
    ],
    imports: [
		NotFoundRoutingModule,
		HttpClientModule,		
        SharedModule
    ]
})

export class NotFoundModule {

 }
