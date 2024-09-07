import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';  // Import Router
import { Employee } from '../models/employee.model';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(
    private employeeService: EmployeeService,
    private router: Router  // Inject Router
  ) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
      .subscribe((data: Employee[]) => {
        this.employees = data;
      });
  }

  editEmployee(id: number): void {
    // Navigate to the Employee Form Component for editing
    this.router.navigate(['/employee-form', id]);
  }

  viewEmployee(id: number): void {
    // Navigate to the Employee Detail Component
    this.router.navigate(['/employee-detail', id]);
  }
}
