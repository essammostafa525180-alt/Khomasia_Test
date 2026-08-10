import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturnDetail, VendorReturnDetail } from '../../../Shared/Model/-vendor-return-detail.model';

@Injectable({ providedIn: 'root' })
export class VendorReturnDetailService extends BaseService<CreateVendorReturnDetail, VendorReturnDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturnDetail);
  }
}
