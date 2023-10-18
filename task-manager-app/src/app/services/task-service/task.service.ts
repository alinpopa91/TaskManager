import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../../models/task';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(environment.SERVER_URL + '/api/Task/GetAllTasks');
  }

  getTaskById(id: number): Observable<Task> {
    let params = new HttpParams()
      .append('taskId', id);

    return this.http.get<Task>(environment.SERVER_URL + '/api/Task/GetTask', { params: params });
  }

  editTask(task: Task): Observable<any> {

    const url = `${environment.SERVER_URL}/api/Task/EditTask`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.put<Task>(url, task, { headers: headers }).pipe(
      catchError((error: any) => {
        console.error('An error occurred:', error);
        return throwError(error);
      })
    );
  }

  addTask(task: Task): Observable<any> {

    const url = `${environment.SERVER_URL}/api/Task/AddTask`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<Task>(url, task, { headers: headers }).pipe(
      catchError((error: any) => {
        console.error('An error occurred:', error);
        return throwError(error);
      })
    );
  }

  getTaskSummary(taskId: number): Observable<string> {
    let params = new HttpParams()
      .append('taskId', taskId);

    return this.http.get<string>(environment.SERVER_URL + '/api/Task/GetTaskSummary', { params: params });
  }

}
