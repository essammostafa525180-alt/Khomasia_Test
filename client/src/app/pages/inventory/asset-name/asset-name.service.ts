import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAsset, Asset } from '../../../Shared/Model/-asset.model';

@Injectable({ providedIn: 'root' })
export class AssetNameService extends BaseService<CreateAsset, Asset> {
  constructor(http: HttpClient) {
    super(http, Configurations.Asset);
  }
}
