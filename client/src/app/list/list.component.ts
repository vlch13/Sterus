import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ListService } from './list.service';
import { ListParams } from '../shared/models/listParams';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
	products: Product[] = [];
	listParams = new ListParams();
	sortOptions = [
		{ name: 'Alphabetical', value: 'name' },
		{ name: 'Price: Low to High', value: 'priceAsc' },
		{ name: 'Price: High to Low', value: 'priceDesc' }
	]
	totalCount = 0;

	constructor(private listService: ListService) { }

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

}
