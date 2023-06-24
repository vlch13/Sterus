import { Component } from '@angular/core';
import { TaskService } from 'src/app/task/task.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {

	constructor(public taskService: TaskService) { }

}
