import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountPlan, AssetCountPlan } from '../../../Shared/Model/-asset-count-plan.model';

@Injectable({ providedIn: 'root' })
export class AssetCountPlanService extends BaseService<CreateAssetCountPlan, AssetCountPlan> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountPlan);
  }
}
