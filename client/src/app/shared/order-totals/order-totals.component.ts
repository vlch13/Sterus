import { Component } from '@angular/core';
import { TaskService } from 'src/app/task/task.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent {

	constructor(public taskService: TaskService) { }
}
