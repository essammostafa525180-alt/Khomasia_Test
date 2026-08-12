import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateApprovalScreen, ApprovalScreen } from '../../../Shared/Model/-approval-screen.model';

@Injectable({ providedIn: 'root' })
export class ApprovalScreenService extends BaseService<CreateApprovalScreen, ApprovalScreen> {
  constructor(http: HttpClient) {
    super(http, Configurations.ApprovalScreen);
  }
}
