import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalMatrix, ApprovalMatrix } from '../../../Shared/Model/-approval-matrix.model';

@Injectable({ providedIn: 'root' })
export class ApprovalMatrixService extends BaseService<CreateApprovalMatrix, ApprovalMatrix> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalMatrix);
  }
}
