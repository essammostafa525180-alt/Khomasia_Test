import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceAsset, PoserviceAsset } from '../../../Shared/Model/-poservice-asset.model';

@Injectable({ providedIn: 'root' })
export class PoserviceAssetService extends BaseService<CreatePoserviceAsset, PoserviceAsset> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceAsset);
  }
}
