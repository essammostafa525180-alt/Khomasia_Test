import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetItemMove, AssetItemMove } from '../../../Shared/Model/-asset-item-move.model';

@Injectable({ providedIn: 'root' })
export class AssetMoveService extends BaseService<CreateAssetItemMove, AssetItemMove> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetItemMove);
  }
}
