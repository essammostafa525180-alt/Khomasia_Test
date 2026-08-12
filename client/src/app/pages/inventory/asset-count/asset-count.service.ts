import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCount, AssetCount } from '../../../Shared/Model/-asset-count.model';

@Injectable({ providedIn: 'root' })
export class AssetCountService extends BaseService<CreateAssetCount, AssetCount> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCount);
  }
}
