import { Component, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from '../services/task-service';
import { TaskStatus } from '../models/task-item';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
})
export class TaskListComponent implements OnInit {
  selectedStatus = signal<TaskStatus | undefined>(undefined);

  constructor(
    public taskService: TaskService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.taskService.loadTasks().subscribe();
  }

  filter(event: Event) {
    const value = (event.target as HTMLSelectElement).value;

    const parsed = value === '' ? undefined : (Number(value) as TaskStatus);

    this.taskService.loadTasks(parsed).subscribe();
  }

  delete(id: string) {
    this.taskService.delete(id).subscribe(() => {
      this.taskService.loadTasks(this.selectedStatus()).subscribe();
    });
  }

  edit(id: string) {
    this.router.navigate(['/tasks', id]);
  }
}
