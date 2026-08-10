import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountPlanType, AssetCountPlanType } from '../../../Shared/Model/-asset-count-plan-type.model';

@Injectable({ providedIn: 'root' })
export class AssetCountPlanTypeService extends BaseService<CreateAssetCountPlanType, AssetCountPlanType> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountPlanType);
  }
}
