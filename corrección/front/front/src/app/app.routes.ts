import { Routes } from '@angular/router';
import { LoginComponent } from './Components/Login/login/login.component';
import { RegisterComponent } from './Components/Register/register/register.component';
import { authGuard } from './custom/auth.guard';
import { ListCitasComponent } from './Components/Citas/list-citas/list-citas.component';

export const routes: Routes = [

    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'Citas', component: ListCitasComponent, canActivate: [authGuard] },


    // { path: 'rolUser', component: ListRolUserComponent, canActivate: [authGuard] },
];
