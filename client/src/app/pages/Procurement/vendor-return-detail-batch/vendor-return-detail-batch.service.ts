import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturnDetailBatch, VendorReturnDetailBatch } from '../../../Shared/Model/-vendor-return-detail-batch.model';

@Injectable({ providedIn: 'root' })
export class VendorReturnDetailBatchService extends BaseService<CreateVendorReturnDetailBatch, VendorReturnDetailBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturnDetailBatch);
  }
}
