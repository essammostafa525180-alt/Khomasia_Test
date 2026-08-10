import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountPlanStatus, AssetCountPlanStatus } from '../../../Shared/Model/-asset-count-plan-status.model';

@Injectable({ providedIn: 'root' })
export class AssetCountPlanStatusService extends BaseService<CreateAssetCountPlanStatus, AssetCountPlanStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountPlanStatus);
  }
}
