import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetDisposed, AssetDisposed } from '../../../Shared/Model/-asset-disposed.model';

@Injectable({ providedIn: 'root' })
export class AssetDisposedService extends BaseService<CreateAssetDisposed, AssetDisposed> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetDisposed);
  }
}
