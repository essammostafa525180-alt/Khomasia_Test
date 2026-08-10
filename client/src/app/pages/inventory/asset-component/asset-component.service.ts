import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetComponent, AssetComponent } from '../../../Shared/Model/-asset-component.model';

@Injectable({ providedIn: 'root' })
export class AssetComponentService extends BaseService<CreateAssetComponent, AssetComponent> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetComponent);
  }
}
