import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountStatus, AssetCountStatus } from '../../../Shared/Model/-asset-count-status.model';

@Injectable({ providedIn: 'root' })
export class AssetCountStatusService extends BaseService<CreateAssetCountStatus, AssetCountStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountStatus);
  }
}
