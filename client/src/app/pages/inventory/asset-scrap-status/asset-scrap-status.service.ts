import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetScrapStatus, AssetScrapStatus } from '../../../Shared/Model/-asset-scrap-status.model';

@Injectable({ providedIn: 'root' })
export class AssetScrapStatusService extends BaseService<CreateAssetScrapStatus, AssetScrapStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetScrapStatus);
  }
}
