import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateZone, Zone } from '../../../Shared/Model/-zone.model';

@Injectable({ providedIn: 'root' })
export class ZoneService extends BaseService<CreateZone, Zone> {
  constructor(http: HttpClient) {
    super(http, Configurations.Zone);
  }
}
