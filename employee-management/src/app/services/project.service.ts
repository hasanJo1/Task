import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private apiUrl = `${environment.apiUrl}/Project`;

  constructor(private http: HttpClient) {}

  getProjects(): Observable<any> {
    debugger
    return this.http.get(this.apiUrl);
  }

  getProject(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  addProject(project: any): Observable<any> {
    debugger
    return this.http.post(this.apiUrl, project);
  }

  updateProject(id: number, project: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, project);
  }

  deleteProject(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
