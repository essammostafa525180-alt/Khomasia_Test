import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetItemScrap, AssetItemScrap } from '../../../Shared/Model/-asset-item-scrap.model';

@Injectable({ providedIn: 'root' })
export class AssetItemScrapService extends BaseService<CreateAssetItemScrap, AssetItemScrap> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetItemScrap);
  }
}
