import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthComponent } from "./auth.component";
import { AuthLoginComponent } from "./login/auth-login.component";

const routes: Routes = [
    {
        path: '',
        component: AuthComponent,
        children: [
            { path: '', component: AuthLoginComponent } 
        ]
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AuthRoutingModule {

}