import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Task, TaskItem } from '../shared/models/task';
import { HttpClient } from '@angular/common/http';
import { Product } from '../shared/models/product';

@Injectable({
	providedIn: 'root'
})
export class TaskService {
	baseUrl = environment.apiUrl;
	private taskSource = new BehaviorSubject<Task | null>(null);
	taskSource$ = this.taskSource.asObservable();

	constructor(private http: HttpClient) { }

	getTask(id: string) {
		return this.http.get<Task>(this.baseUrl + 'task?id=' + id).subscribe({
			next: task => this.taskSource.next(task)
		});
	}

	setTask(task: Task) {
		return this.http.post<Task>(this.baseUrl + 'task', task).subscribe({
			next: task => this.taskSource.next(task)
		});
	}

	getCurrentTaskValue() {
		return this.taskSource.value;
	}

	addItemToTask(item: Product, quantity = 1) {
		const itemToAdd = this.mapProductItemToTaskItem(item);
		const task = this.getCurrentTaskValue() ?? this.createTask();
		task.items = this.addOrUpdateItem(task.items, itemToAdd, quantity);
		this.setTask(task);
	}

	private addOrUpdateItem(items: TaskItem[], itemToAdd: TaskItem, quantity: number): TaskItem[] {
		const item = items.find(x => x.id === itemToAdd.id);
		if (item) item.quantity += quantity;
		else {
			itemToAdd.quantity = quantity;
			items.push(itemToAdd);
		}
		return items;
	}

	private createTask(): Task {
		const task = new Task();
		localStorage.setItem('task_id', task.id);
		return task;
	}

	private mapProductItemToTaskItem(item: Product): TaskItem {
		return {
			id: item.id,
			company: item.productCompany,
			productName: item.name,
			speed: item.speed,
			doseControl: item.doseControl,
			isMedical: item.isMedical,
			quantity: 0,
			price: item.price
			
		}
	}
}
