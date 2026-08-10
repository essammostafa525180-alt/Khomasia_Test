import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderQualityDetail, VendorOrderQualityDetail } from '../../../Shared/Model/-vendor-order-quality-detail.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderQualityDetailService extends BaseService<CreateVendorOrderQualityDetail, VendorOrderQualityDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderQualityDetail);
  }
}
