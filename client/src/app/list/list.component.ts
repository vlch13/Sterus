import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ListService } from './list.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
	products: Product[] = [];

	constructor(private listService: ListService) { }

	ngOnInit(): void {
		this.listService.getProducts().subscribe({
			next: response => this.products = response.data,
			error: error => console.log(error)

		})
	}

}
