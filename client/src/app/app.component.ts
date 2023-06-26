import { Component, OnInit } from '@angular/core';
import { TaskService } from './task/task.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	title = 'Sterus';

	constructor(private taskService: TaskService, private accountService: AccountService) { }

	ngOnInit(): void {
		this.loadTask();
		this.loadCurrentUser();
	}

	loadTask() {
		const taskId = localStorage.getItem('task_id');
		if (taskId) this.taskService.getTask(taskId);
	}

	loadCurrentUser() {
		const token = localStorage.getItem('token');
		this.accountService.loadCurrentUser(token).subscribe();
	}
}
