import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateEmployeeJob, EmployeeJob } from '../../../Shared/Model/-employee-job.model';

@Injectable({ providedIn: 'root' })
export class EmployeeJobService extends BaseService<CreateEmployeeJob, EmployeeJob> {
  constructor(http: HttpClient) {
    super(http, Configurations.EmployeeJob);
  }
}
