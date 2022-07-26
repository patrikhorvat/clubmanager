import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { NotFoundComponent } from "./notfound.component";
import { AuthGuard } from "../core/services/auth-guard.service";

const routes: Routes = [
    {
        path: '',
        component: NotFoundComponent,
        children: [
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class NotFoundRoutingModule {
	
	constructor() {

    }
}
