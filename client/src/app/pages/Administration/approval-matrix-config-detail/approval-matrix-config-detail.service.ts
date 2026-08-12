import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalMatrixConfigDetail, ApprovalMatrixConfigDetail } from '../../../Shared/Model/-approval-matrix-config-detail.model';

@Injectable({ providedIn: 'root' })
export class ApprovalMatrixConfigDetailService extends BaseService<CreateApprovalMatrixConfigDetail, ApprovalMatrixConfigDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalMatrixConfigDetail);
  }
}
