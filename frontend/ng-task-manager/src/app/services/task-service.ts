import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskItem } from '../models/task-item';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TaskService {
  private baseUrl = 'https://localhost:7090/api/tasks';

  tasks = signal<TaskItem[]>([]);
  loading = signal(false);

  constructor(private http: HttpClient) {}

  loadTasks(status?: number) {
    this.loading.set(true);

    const url = status !== undefined ? `${this.baseUrl}?status=${status}` : this.baseUrl;

    return this.http.get<TaskItem[]>(url).pipe(
      tap({
        next: (data) => {
          this.tasks.set(data);
          this.loading.set(false);
        },
        error: () => this.loading.set(false),
      }),
    );
  }

  create(task: Partial<TaskItem>) {
    return this.http.post<TaskItem>(this.baseUrl, task);
  }

  update(id: string, task: Partial<TaskItem>) {
    return this.http.put(`${this.baseUrl}/${id}`, task);
  }

  delete(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getById(id: string) {
    return this.http.get<TaskItem>(`${this.baseUrl}/${id}`);
  }
}
