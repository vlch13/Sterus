import { Component, Input } from '@angular/core';
import { Product } from 'src/app/shared/models/product';
import { TaskService } from 'src/app/task/task.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
	@Input() product?: Product;

	constructor(private taskService: TaskService) { }

	addItemToTask() {
		this.product && this.taskService.addItemToTask(this.product)
	}
}
