import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderQualityDetailBatch, VendorOrderQualityDetailBatch } from '../../../Shared/Model/-vendor-order-quality-detail-batch.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderQualityDetailBatchService extends BaseService<CreateVendorOrderQualityDetailBatch, VendorOrderQualityDetailBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderQualityDetailBatch);
  }
}
