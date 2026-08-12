import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCompline, AssetCompline } from '../../../Shared/Model/-asset-compline.model';

@Injectable({ providedIn: 'root' })
export class AssetComplineService extends BaseService<CreateAssetCompline, AssetCompline> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCompline);
  }
}
