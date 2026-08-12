import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalMatrixDetail, ApprovalMatrixDetail } from '../../../Shared/Model/-approval-matrix-detail.model';

@Injectable({ providedIn: 'root' })
export class ApprovalMatrixDetailService extends BaseService<CreateApprovalMatrixDetail, ApprovalMatrixDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalMatrixDetail);
  }
}
