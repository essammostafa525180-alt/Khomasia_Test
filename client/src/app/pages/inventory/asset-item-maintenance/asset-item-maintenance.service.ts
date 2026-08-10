import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetItemMaintenance, AssetItemMaintenance } from '../../../Shared/Model/-asset-item-maintenance.model';

@Injectable({ providedIn: 'root' })
export class AssetItemMaintenanceService extends BaseService<CreateAssetItemMaintenance, AssetItemMaintenance> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetItemMaintenance);
  }
}
