import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeClass } from '../app.component';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  constructor(private http: HttpClient) {}

  private baseURL = `https://localhost:49155/Employee`;

  getAllData(): Observable<any> {
    return this.http.get<any>(`${this.baseURL} `);
  }

  UpdateWork(data: any): Observable<EmployeeClass> {
      return this.http.post<any>(`${this.baseURL}/Work`, data);
  }

  UpdateTakeVacation(data: any): Observable<EmployeeClass> {
    return this.http.post<any>(`${this.baseURL}/TakeVacation`, data);
  }
}
