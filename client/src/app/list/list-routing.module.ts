import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
	{ path: '', component: ListComponent },
	{ path: ':id', component: ProductDetailsComponent },
]

@NgModule({
	declarations: [],
	imports: [
		RouterModule.forChild(routes)
	],
	exports: [
		RouterModule
	]
})
export class ListRoutingModule { }
