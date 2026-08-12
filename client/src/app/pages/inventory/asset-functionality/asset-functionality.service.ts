import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetFunctionality, AssetFunctionality } from '../../../Shared/Model/-asset-functionality.model';

@Injectable({ providedIn: 'root' })
export class AssetFunctionalityService extends BaseService<CreateAssetFunctionality, AssetFunctionality> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetFunctionality);
  }
}
