import { Project } from "./project.model";


export interface Employee {
    id: number;
    name: string;
    position: string;
    projects: Project[];
  }

  export interface AssignEmployeeToProjectDTO {
    EmployeeId: number;
    ProjectIds: number[];
  }