import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	title = 'Sterus';
	products: Product[] = [];

	constructor(private http: HttpClient) { }

	ngOnInit(): void {
		this.http.get<Pagination<Product[]>>('https://localhost:5005/api/products?pageSize=50').subscribe({
			next: response => this.products = response.data, //what ot do next
			error: error => console.log(error), //what to do of error
			complete: () => {
				console.log('Request completed');
				console.log('Extra statment');
			}
		})
	}
}
