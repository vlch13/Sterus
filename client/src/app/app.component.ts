import { Component, OnInit } from '@angular/core';
import { TaskService } from './task/task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	title = 'Sterus';

	constructor(private taskService: TaskService) { }

	ngOnInit(): void {
		const taskId = localStorage.getItem('task_id');
		if (taskId) this.taskService.getTask(taskId);
	}
}
