import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateWorkerType, WorkerType } from '../../../Shared/Model/-worker-type.model';

@Injectable({ providedIn: 'root' })
export class WorkerTypeService extends BaseService<CreateWorkerType, WorkerType> {
  constructor(http: HttpClient) {
    super(http, Configurations.WorkerType);
  }
}
