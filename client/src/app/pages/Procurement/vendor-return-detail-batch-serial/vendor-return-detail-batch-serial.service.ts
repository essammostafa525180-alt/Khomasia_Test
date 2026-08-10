import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturnDetailBatchSerial, VendorReturnDetailBatchSerial } from '../../../Shared/Model/-vendor-return-detail-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class VendorReturnDetailBatchSerialService extends BaseService<CreateVendorReturnDetailBatchSerial, VendorReturnDetailBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturnDetailBatchSerial);
  }
}
