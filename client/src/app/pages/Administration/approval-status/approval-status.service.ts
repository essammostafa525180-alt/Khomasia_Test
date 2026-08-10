import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalStatus, ApprovalStatus } from '../../../Shared/Model/-approval-status.model';

@Injectable({ providedIn: 'root' })
export class ApprovalStatusService extends BaseService<CreateApprovalStatus, ApprovalStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalStatus);
  }
}
