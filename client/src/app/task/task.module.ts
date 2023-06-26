import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskComponent } from './task.component';
import { TaskRoutingModule } from './task-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
	declarations: [
		TaskComponent
	],
	imports: [
		CommonModule,
		TaskRoutingModule,
		SharedModule
	]
})
export class TaskModule { }
