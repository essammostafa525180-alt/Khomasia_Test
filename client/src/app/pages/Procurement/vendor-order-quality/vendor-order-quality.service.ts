import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderQuality, VendorOrderQuality } from '../../../Shared/Model/-vendor-order-quality.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderQualityService extends BaseService<CreateVendorOrderQuality, VendorOrderQuality> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderQuality);
  }
}
