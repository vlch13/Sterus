import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Product } from '../shared/models/product';
import { ListService } from './list.service';
import { ListParams } from '../shared/models/listParams';
import { TaskService } from '../task/task.service';

@Component({
	selector: 'app-list',
	templateUrl: './list.component.html',
	styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
	@ViewChild('search') searchTerm?: ElementRef;
	products: Product[] = [];
	listParams = new ListParams();
	sortOptions = [
		{ name: 'Alphabetical', value: 'name' },
		{ name: 'Price: Low to High', value: 'priceAsc' },
		{ name: 'Price: High to Low', value: 'priceDesc' }
	]
	totalCount = 0;

	// @Input() product?: Product /////////

	constructor(private listService: ListService, private taskService: TaskService) { }

	ngOnInit(): void {
		this.getProducts();
	}

	getProducts() {
		this.listService.getProducts(this.listParams).subscribe({
			next: response => {
				this.products = response.data;
				this.listParams.pageNumber = response.pageIndex;
				this.listParams.pageSize = response.pageSize;
				this.totalCount = response.count;
			},
			error: error => console.log(error)

		})
	}

	onPageChanged(event: any) {
		if (this.listParams.pageNumber !== event) {
			this.listParams.pageNumber = event;
			this.getProducts();
		}
	}

	onSearch() {
		this.listParams.search = this.searchTerm?.nativeElement.value;
		this.getProducts();
	}

	onReset() {
		if (this.searchTerm) this.searchTerm.nativeElement.value = '';
		this.listParams = new ListParams();
		this.getProducts();

	}

	// addItemToTask() { ////// нужно достать конкретный product
	// 	this.product && this.taskService.addItemToTask(this.product)
	// }
}
