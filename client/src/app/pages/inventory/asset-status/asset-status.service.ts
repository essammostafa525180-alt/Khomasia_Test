import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetStatus, AssetStatus } from '../../../Shared/Model/-asset-status.model';

@Injectable({ providedIn: 'root' })
export class AssetStatusService extends BaseService<CreateAssetStatus, AssetStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetStatus);
  }
}
