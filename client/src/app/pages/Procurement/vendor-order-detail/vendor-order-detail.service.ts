import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderDetail, VendorOrderDetail } from '../../../Shared/Model/-vendor-order-detail.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderDetailService extends BaseService<CreateVendorOrderDetail, VendorOrderDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderDetail);
  }
}
