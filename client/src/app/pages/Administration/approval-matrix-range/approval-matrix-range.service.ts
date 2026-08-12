import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalMatrixRange, ApprovalMatrixRange } from '../../../Shared/Model/-approval-matrix-range.model';

@Injectable({ providedIn: 'root' })
export class ApprovalMatrixRangeService extends BaseService<CreateApprovalMatrixRange, ApprovalMatrixRange> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalMatrixRange);
  }
}
