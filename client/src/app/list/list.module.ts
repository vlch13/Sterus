import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';



@NgModule({
	declarations: [
		ListComponent,
		ProductItemComponent,
		ProductDetailsComponent
	],
	imports: [
		CommonModule,
		SharedModule,
		RouterModule
	],
	exports: [
		ListComponent
	]
})
export class ListModule { }
