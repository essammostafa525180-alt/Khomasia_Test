import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountDetail, AssetCountDetail } from '../../../Shared/Model/-asset-count-detail.model';

@Injectable({ providedIn: 'root' })
export class AssetCountDetailService extends BaseService<CreateAssetCountDetail, AssetCountDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountDetail);
  }
}
