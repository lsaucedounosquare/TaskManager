import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../services/task-service';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  imports: [ReactiveFormsModule],
})
export class TaskFormComponent implements OnInit {
  form!: FormGroup;
  id?: string;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      description: [''],
      status: [0],
    });

    this.id = this.route.snapshot.paramMap.get('id') || undefined;
    this.isEdit = !!this.id;

    if (this.isEdit && this.id) {
      this.taskService.getById(this.id).subscribe((task) => {
        this.form.patchValue({
          title: task.title,
          description: task.description,
          status: task.status,
        });
      });
    }
  }

  submit() {
    if (this.form.invalid) return;

    const payload = {
      ...this.form.value,
      status: Number(this.form.value.status),
    };

    if (this.isEdit && this.id) {
      this.taskService.update(this.id, payload).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    } else {
      this.taskService.create(payload).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    }
  }
}
