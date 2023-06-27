import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from '../core/guards/auth.guard';

const routes: Routes = [
	{ path: 'login', component: LoginComponent },
	{ path: 'register', canActivate: [AuthGuard], component: RegisterComponent },
]

@NgModule({
	declarations: [],
	imports: [
		RouterModule.forChild(routes)
	],
	exports: [
		RouterModule
	]
})
export class AccountRoutingModule { }
