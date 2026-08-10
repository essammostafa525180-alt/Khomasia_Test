import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceiveDetailBatchSerial, VendorOrderReceiveDetailBatchSerial } from '../../../Shared/Model/-vendor-order-receive-detail-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderReceiveDetailBatchSerialService extends BaseService<CreateVendorOrderReceiveDetailBatchSerial, VendorOrderReceiveDetailBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceiveDetailBatchSerial);
  }
}
