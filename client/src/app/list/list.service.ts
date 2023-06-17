import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ListParams } from '../shared/models/listParams';

@Injectable({
	providedIn: 'root'
})
export class ListService {
	baseUrl = 'https://localhost:5005/api/';

	constructor(private http: HttpClient) { }

	getProducts(listParams: ListParams) {
		let params = new HttpParams();
		
		params = params.append('sort', listParams.sort)
		params = params.append('pageIndex', listParams.pageNumber)
		params = params.append('pageSize', listParams.pageSize)
		if (listParams.search) params = params.append('search', listParams.search)
		
		// return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products?pageSize=15'); 94.98
		return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', {params: params});
	}

	getProduct(id: number) {
		return this.http.get<Product>(this.baseUrl + 'products/' + id);
	}
}
