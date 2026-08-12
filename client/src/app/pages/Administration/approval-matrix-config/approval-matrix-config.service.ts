import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalMatrixConfig, ApprovalMatrixConfig } from '../../../Shared/Model/-approval-matrix-config.model';

@Injectable({ providedIn: 'root' })
export class ApprovalMatrixConfigService extends BaseService<CreateApprovalMatrixConfig, ApprovalMatrixConfig> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalMatrixConfig);
  }
}
