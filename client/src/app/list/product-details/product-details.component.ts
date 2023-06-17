import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { ListService } from '../list.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent {
	product?: Product;

	constructor(private listService: ListService, private activatedRoute: ActivatedRoute) { }

	ngOnInit(): void {
		this.loadProduct();
	}

	loadProduct() {
		const id = this.activatedRoute.snapshot.paramMap.get('id');
		if (id) this.listService.getProduct(+id).subscribe({
			next: product => this.product = product,
			error: error => console.log(error)
		})
	}
}
