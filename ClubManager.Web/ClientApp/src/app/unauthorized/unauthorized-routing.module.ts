import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { UnauthorizedComponent } from "./unauthorized.component";
import { AuthGuard } from "../core/services/auth-guard.service";

const routes: Routes = [
    {
        path: '',
        component: UnauthorizedComponent,
        canActivate: [AuthGuard],
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
export class UnauthorizedRoutingModule {
	
	constructor() {

    }
}
