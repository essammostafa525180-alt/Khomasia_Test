import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetWarrantyStatus, AssetWarrantyStatus } from '../../../Shared/Model/-asset-warranty-status.model';

@Injectable({ providedIn: 'root' })
export class AssetWarrantyStatusService extends BaseService<CreateAssetWarrantyStatus, AssetWarrantyStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetWarrantyStatus);
  }
}
