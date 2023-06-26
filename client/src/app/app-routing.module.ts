import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'test-error', component: TestErrorComponent },
	{ path: 'not-found', canActivate: [AuthGuard], component: NotFoundComponent },
	{ path: 'server-error', component: ServerErrorComponent },
	{ path: 'list', canActivate: [AuthGuard], loadChildren: () => import('./list/list.module').then(m => m.ListModule) },
	{ path: 'task', canActivate: [AuthGuard], loadChildren: () => import('./task/task.module').then(m => m.TaskModule) },
	{ path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
	{ path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
