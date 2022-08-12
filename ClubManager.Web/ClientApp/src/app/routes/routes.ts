import { Routes } from '@angular/router';
import { AuthGuard } from '../core/services/auth-guard.service';
import { LayoutComponent } from '../layout/layout.component';

export const routes: Routes = [
    {
        path: 'auth/:mode',
        loadChildren: ()=>import('../auth/auth.module').then(m=>m.AuthModule)
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {   
                path: '', 
                redirectTo: 'home', 
                pathMatch: "full"
            },
            { 
                path: 'home', 
                canActivate: [AuthGuard],
                loadChildren: () => import('./home/home.module').then(m => m.HomeModule) 
            },
            {
                path: 'employees', loadChildren: () => import('../employees/employees.module').then(m => m.EmployeesModule)
            },
            {
                path: 'not-found',
                loadChildren: ()=>import('../notfound/notfound.module').then(m=>m.NotFoundModule)
            },
            {
                path: 'unauthorized',
                loadChildren: ()=>import('../unauthorized/unauthorized.module').then(m=>m.UnauthorizedModule)
            },
            {
                path: '**',
                redirectTo: 'not-found'
            }
        ]
    },

    // Not found
    { path: '**', redirectTo: 'home' }

];
