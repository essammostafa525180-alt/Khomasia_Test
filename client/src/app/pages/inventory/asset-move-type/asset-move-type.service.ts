import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetMoveType, AssetMoveType } from '../../../Shared/Model/-asset-move-type.model';

@Injectable({ providedIn: 'root' })
export class AssetMoveTypeService extends BaseService<CreateAssetMoveType, AssetMoveType> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetMoveType);
  }
}
