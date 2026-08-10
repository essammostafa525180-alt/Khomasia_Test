import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateEmployee, Employee } from '../../../Shared/Model/-employee.model';

@Injectable({ providedIn: 'root' })
export class EmployeeService extends BaseService<CreateEmployee, Employee> {
  constructor(http: HttpClient) {
    super(http, Configurations.Employee);
  }
}
