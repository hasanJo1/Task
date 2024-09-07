import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Employee } from '../models/employee.model';
import { Project } from '../models/project.model';  // Import the Project model
import { EmployeeService } from '../services/employee.service';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee = { id: 0, name: '', position: '', projects: [] };
  isEditMode: boolean = false;
  isProjectSelectionOpen: boolean = false;
  availableProjects: Project[] = [];  // Use the Project model

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute,
    private projectService: ProjectService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.employeeService.getEmployee(+id).subscribe(employee => {
          this.employee = employee;
        });
      }
    });

    this.projectService.getProjects().subscribe({
      next: (projects) => {
        this.availableProjects = projects;
      },
      error: (err) => {
        console.error('Failed to load projects:', err);
        // Handle error (e.g., show a notification to the user)
      }
    });
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.employeeService.addEmployee(this.employee).subscribe({
        
        next: () => this.assign(this.employee),
        error: (err) => {
          console.error('Failed to update employee:', err);
          
          // Handle error (e.g., show a notification to the user)
        }
      });
    } else {
      this.employeeService.addEmployee(this.employee).subscribe({
        next: () => this.router.navigate(['/employee-list']),
        error: (err) => {
          console.error('Failed to add employee:', err);
          // Handle error (e.g., show a notification to the user)
        }
      });
    }

  
  }

  addProject(): void {
    this.employee.projects.push({ id: 0, name: '', description: '' });
  }

  removeProject(index: number): void {
    this.employee.projects.splice(index, 1);
  }

  openProjectSelection(): void {
    this.isProjectSelectionOpen = true;
  }

  closeProjectSelection(): void {
    this.isProjectSelectionOpen = false;
  }

  assignProject(project: Project): void {
    
    if (!this.employee.projects.some(p => p.id === project.id)) {
      this.employee.projects.push(project);
    }
    this.closeProjectSelection();
  }

  assign(employee: any): void {
    debugger
    this.employeeService.assignEmployeesToProjects(employee).subscribe({
      next: () => this.router.navigate(['/employee-list']),
      error: (err) => {
        console.error('Failed to add employee:', err);
        // Handle error (e.g., show a notification to the user)
      }
    });
  }
}
