import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceiveDetail, VendorOrderReceiveDetail } from '../../../Shared/Model/-vendor-order-receive-detail.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderReceiveDetailService extends BaseService<CreateVendorOrderReceiveDetail, VendorOrderReceiveDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceiveDetail);
  }
}
