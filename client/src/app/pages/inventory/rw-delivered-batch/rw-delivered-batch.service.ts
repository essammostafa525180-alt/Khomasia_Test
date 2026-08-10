import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwDeliveredBatch, RwDeliveredBatch } from '../../../Shared/Model/-rw-delivered-batch.model';

@Injectable({ providedIn: 'root' })
export class RwDeliveredBatchService extends BaseService<CreateRwDeliveredBatch, RwDeliveredBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwDeliveredBatch);
  }
}
