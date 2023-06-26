import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Task, TaskItem, TaskTotals } from '../shared/models/task';
import { HttpClient } from '@angular/common/http';
import { Product } from '../shared/models/product';

@Injectable({
	providedIn: 'root'
})
export class TaskService {
	baseUrl = environment.apiUrl;
	private taskSource = new BehaviorSubject<Task | null>(null);
	taskSource$ = this.taskSource.asObservable();
	private taskTotalSource = new BehaviorSubject<TaskTotals | null>(null); //153
	taskTotalSource$ = this.taskTotalSource.asObservable(); //153

	constructor(private http: HttpClient) { }

	getTask(id: string) {
		return this.http.get<Task>(this.baseUrl + 'task?id=' + id).subscribe({
			next: task => {
				this.taskSource.next(task);
				this.calculateTotals();
			}
		});
	}

	setTask(task: Task) {
		return this.http.post<Task>(this.baseUrl + 'task', task).subscribe({
			// next: task => this.taskSource.next(task)
			next: task => {
				this.taskSource.next(task);
				this.calculateTotals();
			}
		});
	}

	getCurrentTaskValue() {
		return this.taskSource.value;
	}

	addItemToTask(item: Product | TaskItem, quantity = 1) {
		// const itemToAdd = this.mapProductItemToTaskItem(item);
		if (this.isProduct(item)) item = this.mapProductItemToTaskItem(item);
		const task = this.getCurrentTaskValue() ?? this.createTask();
		// task.items = this.addOrUpdateItem(task.items, itemToAdd, quantity);
		task.items = this.addOrUpdateItem(task.items, item, quantity);
		this.setTask(task);
	}

	removeItemFromTask(id: number, quantity = 1) {
		const task = this.getCurrentTaskValue();
		if (!task) return;
		const item = task.items.find(x => x.id === id);
		if (item) {
			item.quantity -= quantity;
			if (item.quantity <= 0) {
				task.items = task.items.filter(x => x.id !== id);
			}
			if (task.items.length > 0) this.setTask(task);
			else this.deleteTask(task);
		}
	}

	deleteTask(task: Task) {
		return this.http.delete(this.baseUrl + 'task?id=' + task.id).subscribe({
			next: () => {
				this.taskSource.next(null);
				localStorage.removeItem('task_id');
			}
		})
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

	private calculateTotals() { //153
		const task = this.getCurrentTaskValue();
		if (!task) return;
		const total = task.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
		const time = task.items.reduce((a, b) => ((0.04404 / b.speed) * b.quantity) + a, 1).toFixed(1);
		this.taskTotalSource.next({ total, time });
	}

	private isProduct(item: Product | TaskItem): item is Product { //156
		return (item as Product).productCompany !== undefined;
	}
}
