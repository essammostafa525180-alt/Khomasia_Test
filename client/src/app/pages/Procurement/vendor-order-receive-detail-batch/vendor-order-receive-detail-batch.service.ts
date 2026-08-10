import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceiveDetailBatch, VendorOrderReceiveDetailBatch } from '../../../Shared/Model/-vendor-order-receive-detail-batch.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderReceiveDetailBatchService extends BaseService<CreateVendorOrderReceiveDetailBatch, VendorOrderReceiveDetailBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceiveDetailBatch);
  }
}
