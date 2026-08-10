import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetMaintenanceStatus, AssetMaintenanceStatus } from '../../../Shared/Model/-asset-maintenance-status.model';

@Injectable({ providedIn: 'root' })
export class AssetMaintenanceStatusService extends BaseService<CreateAssetMaintenanceStatus, AssetMaintenanceStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetMaintenanceStatus);
  }
}
