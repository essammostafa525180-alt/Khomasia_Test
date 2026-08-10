import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCommissioning, AssetCommissioning } from '../../../Shared/Model/-asset-commissioning.model';

@Injectable({ providedIn: 'root' })
export class AssetCommissioningService extends BaseService<CreateAssetCommissioning, AssetCommissioning> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCommissioning);
  }
}
