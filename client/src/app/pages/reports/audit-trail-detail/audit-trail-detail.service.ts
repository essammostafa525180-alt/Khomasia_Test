import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAuditTrailDetail, AuditTrailDetail } from '../../../Shared/Model/-audit-trail-detail.model';

@Injectable({ providedIn: 'root' })
export class AuditTrailDetailService extends BaseService<CreateAuditTrailDetail, AuditTrailDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.AuditTrailDetail);
  }
}
