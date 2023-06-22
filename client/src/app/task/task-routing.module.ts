import { NgModule } from '@angular/core';
import { TaskComponent } from './task.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
	{ path: '', component: TaskComponent }
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
export class TaskRoutingModule { }
