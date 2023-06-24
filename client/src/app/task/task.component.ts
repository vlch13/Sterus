import { Component } from '@angular/core';
import { TaskService } from './task.service';
import { TaskItem } from '../shared/models/task';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent {

	constructor(public taskService: TaskService) { }
	
	incrementQuantity(item: TaskItem, quantity: number) {
		this.taskService.addItemToTask(item, quantity);
	}

	removeItem(id: number, quantity: number) {
		this.taskService.removeItemFromTask(id, quantity);
	}
}
