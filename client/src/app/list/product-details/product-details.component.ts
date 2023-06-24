import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { ListService } from '../list.service';
import { TaskService } from 'src/app/task/task.service';
import { take } from 'rxjs';

@Component({
	selector: 'app-product-details',
	templateUrl: './product-details.component.html',
	styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent {
	product?: Product;
	quantity = 1;
	quantityInTask = 0;

	constructor(private listService: ListService, private activatedRoute: ActivatedRoute,
		private taskService: TaskService) { }

	ngOnInit(): void {
		this.loadProduct();
	}

	// loadProduct() {
	// 	const id = this.activatedRoute.snapshot.paramMap.get('id');
	// 	if (id) this.listService.getProduct(+id).subscribe({
	// 		next: product => this.product = product,
	// 		error: error => console.log(error)
	// 	})
	// }

	loadProduct() {
		const id = this.activatedRoute.snapshot.paramMap.get('id');
		if (id) this.listService.getProduct(+id).subscribe({
			next: product => {
				this.product = product;
				this.taskService.taskSource$.pipe(take(1)).subscribe({
					next: task => {
						const item = task?.items.find(x => x.id === +id);
						if (item) {
							this.quantity = item.quantity;
							this.quantityInTask = item.quantity;
						}
					}
				})
			},
			error: error => console.log(error)
		})
	}

	incrementQuantity(quantity: number) {
		this.quantity += quantity;
	}
	decrementQuantity(quantity: number) {
		this.quantity -= quantity;
		if (this.quantity <= 0) this.quantity = 0;	
	}

	updateTask() {
		if (this.product) {
			if (this.quantity > this.quantityInTask) {
				const itemsToAdd = this.quantity - this.quantityInTask;
				this.quantityInTask += itemsToAdd;
				this.taskService.addItemToTask(this.product, itemsToAdd);
			} else {
				const itemsToRemove = this.quantityInTask - this.quantity;
				this.quantityInTask -= itemsToRemove;
				this.taskService.removeItemFromTask(this.product.id, itemsToRemove);
			}
		}
	}

	get buttonText() {
		return this.quantityInTask === 0 ? 'В задание' : 'Обновить';
	}
}
