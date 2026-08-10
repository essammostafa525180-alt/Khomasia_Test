import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetItem, AssetItem } from '../../../Shared/Model/-asset-item.model';

@Injectable({ providedIn: 'root' })
export class AssetItemService extends BaseService<CreateAssetItem, AssetItem> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetItem);
  }
}
