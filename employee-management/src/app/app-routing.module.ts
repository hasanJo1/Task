// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProjectFormComponent } from './project-form/project-form.component';


const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'employee-detail/:id', component: EmployeeDetailsComponent },
  { path: 'employee-form', component: EmployeeFormComponent },
  { path: 'project-form', component: ProjectFormComponent },
  { path: 'employee-form/:id', component: EmployeeFormComponent },
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' },
  { path: '**', redirectTo: '/employee-list' }  // Optional: Handle unknown routes
];

@NgModule({
  
  imports: [RouterModule.forRoot(routes),ReactiveFormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }