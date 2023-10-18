import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Task } from '../../models/task';
import { User } from '../../models/user';
import { TaskService } from '../../services/task-service/task.service';
import { UserService } from '../../services/user-service/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DialogService } from 'primeng/dynamicdialog';
import { SuccessMessageComponent } from '../../components/success-message/success-message.component'; 

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  task: Task = new Task();
  users: User[];
  addTaskForm: FormGroup;
  submitted = false;


  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private taskService: TaskService,
    private userService: UserService,
    private router: Router,
    private dialogService: DialogService
  ) { }


  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.getTask(id);
      this.getUsers();
    });


    this.addTaskForm = this.formBuilder.group({
      TaskName: ['', Validators.required],
      TaskDescription: [''],
      IsComplete: [''],
      UserId: [''],
      User: ['']
    });

  }

  //get addTaskFormControl() { return this.addTaskForm.controls; }

  getTask(id: number) {
    this.taskService.getTaskById(id)
    .subscribe(
      (task: Task) => {
        this.task = task;
      },
      (error: any) => {
        console.error('A apărut o eroare:', error);
      }
    );;
  }

  getUsers() {
    this.userService.getUsers()
    .subscribe(
      (users: User[]) => {
        this.users = users;
      },
      (error: any) => {
        console.error('A apărut o eroare:', error);
      }
    );;
  }

  saveTask() {
    this.submitted = true;
    if (this.addTaskForm.invalid) {
      return;
    }

    this.taskService.addTask(this.task).subscribe(
      () => {
        this.openModal('success', 'Task updated successfully!');
      },
      (error) => {
        this.openModal('error', 'An error occurred while updating the task.');
      }
    );

  }

  isTaskNameInvalid(): boolean {
    const control = this.addTaskForm.get('TaskName');
    return control ? control.hasError('required') && control.touched : false;
  }

  isTaskDescriptionInvalid(): boolean {
    const control = this.addTaskForm.get('TaskDescription');
    return control ? control.hasError('required') && control.touched || (control.value && control.value.length < 5) : false;
  }

  openModal(type: string, message: string) {
    if (type === 'success') {
      const ref = this.dialogService.open(SuccessMessageComponent, {
        header: 'Success',
        data: { message: message },
        styleClass: 'p-dialog-sm',
      });
    } else if (type === 'error') {
      const ref = this.dialogService.open(SuccessMessageComponent, {
        header: 'Error',
        data: { message: message },
        styleClass: 'p-dialog-sm',
      });
    }
  }

}
