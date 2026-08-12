import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateReturnStatus, ReturnStatus } from '../../../Shared/Model/-return-status.model';

@Injectable({ providedIn: 'root' })
export class ReturnStatusService extends BaseService<CreateReturnStatus, ReturnStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ReturnStatus);
  }
}
