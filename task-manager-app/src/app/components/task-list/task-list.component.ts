import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Task } from '../../models/task';
import { TaskService } from '../../services/task-service/task.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(
    private taskService: TaskService, 
    private router: Router) { }

  ngOnInit(): void {
    this.getTasks();
  }

  getTasks(): void {
    this.taskService.getTasks()
      .subscribe(
        (tasks: Task[]) => {
          this.tasks = tasks;
        },
        (error: any) => {
          console.error('A apărut o eroare:', error);
        }
      );
  }

  addTask(): void {
    this.router.navigate(['/add-task']);
  }

  editTask(id: number) {
    this.router.navigate(['/edit-task', id]);
  }

}