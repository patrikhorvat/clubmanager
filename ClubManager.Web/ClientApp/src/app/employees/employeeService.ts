import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/core/http/api.service';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class EmployeeService {

  constructor(private apiService: ApiService) { }

  get(id: number) {
    return this.apiService.get("/employee/" + id);
  }
  createEmployee(model: any) {
    return this.apiService.post("/employee/create", model);
  }
  changeStatus(id: number, statusId: number) {
    return this.apiService.patch(`/employee/${id}/status/${statusId}`);
  }
  updateEmployee(model: any) {
    return this.apiService.put("/employee/update", model);
  }

  getEmployeeTypes() {
    return this.apiService.get("/employee/types");
  }

  deleteEmployee(id: number) {
    return this.apiService.delete("/employee/" + id);
  }

}

