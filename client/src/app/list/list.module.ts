import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { ProductItemComponent } from './product-item/product-item.component';



@NgModule({
	declarations: [
		ListComponent,
		ProductItemComponent
	],
	imports: [
		CommonModule
	],
	exports: [
		ListComponent
	]
})
export class ListModule { }
