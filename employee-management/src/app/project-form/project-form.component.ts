import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../models/project.model';  // Import the Project model
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-project-form',
  templateUrl: './project-form.component.html',
  styleUrls: ['./project-form.component.css']
})
export class ProjectFormComponent implements OnInit {
  Projects: Project = { id: 0, name: '', description: '' };
  isEditMode: boolean = false;
  availableProjects: Project[] = [];  // Use the Project model

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private projectService: ProjectService
  ) { }

  ngOnInit(): void {
    this.projectService.getProjects().subscribe({
      next: (projects) => {
        this.availableProjects = projects;
      },
      error: (err) => {
        console.error('Failed to load projects:', err);
      }
    });
  }

  onSubmit(): void {
    if (this.isEditMode) {
      // Update existing project logic
      this.projectService.addProject(this.Projects).subscribe({
        next: () => this.router.navigate(['/employee-list']),
        error: (err) => {
          console.error('Failed to update project:', err);
        }
      });
    } else {
      // Add new project logic
      this.projectService.addProject(this.Projects).subscribe({
        next: () => this.router.navigate(['/employee-list']),
        error: (err) => {
          console.error('Failed to add project:', err);
        }
      });
    }
  }

  onProjectSelect(project: Project): void {
    this.Projects = { ...project };  // Clone the selected project
    this.isEditMode = true;
  }
}
