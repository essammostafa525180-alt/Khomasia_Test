import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateZoneStatus, ZoneStatus } from '../../../Shared/Model/-zone-status.model';

@Injectable({ providedIn: 'root' })
export class ZoneStatusService extends BaseService<CreateZoneStatus, ZoneStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ZoneStatus);
  }
}
