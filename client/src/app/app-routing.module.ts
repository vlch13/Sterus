import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListComponent } from './list/list.component';
import { ProductDetailsComponent } from './list/product-details/product-details.component';

const routes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'list', component: ListComponent },
	{ path: 'list/:id', component: ProductDetailsComponent },
	{ path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
