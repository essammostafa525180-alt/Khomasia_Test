import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAuditTrail, AuditTrail } from '../../../Shared/Model/-audit-trail.model';

@Injectable({ providedIn: 'root' })
export class AuditTrailService extends BaseService<CreateAuditTrail, AuditTrail> {
  constructor(http: HttpClient) {
    super(http, Configurations.AuditTrail);
  }
}
