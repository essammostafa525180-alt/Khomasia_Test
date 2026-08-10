import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountPlanDetail, AssetCountPlanDetail } from '../../../Shared/Model/-asset-count-plan-detail.model';

@Injectable({ providedIn: 'root' })
export class AssetCountPlanDetailService extends BaseService<CreateAssetCountPlanDetail, AssetCountPlanDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountPlanDetail);
  }
}
