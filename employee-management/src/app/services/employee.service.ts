import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AssignEmployeeToProjectDTO } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = `${environment.apiUrl}/Employee`;

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<any> {
    debugger
    return this.http.get(this.apiUrl);
  }

  getEmployee(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  addEmployee(employee: any): Observable<any> {
    return this.http.post(this.apiUrl, employee);
  }

  updateEmployee(id: number, employee: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, employee);
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  assignEmployeesToProjects(employee: any): Observable<any> {
    return this.http.post(this.apiUrl+"/assignEmployeesOnProjects", employee);
  }
}
