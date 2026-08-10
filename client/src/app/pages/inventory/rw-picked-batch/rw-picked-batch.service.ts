import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwPickedBatch, RwPickedBatch } from '../../../Shared/Model/-rw-picked-batch.model';

@Injectable({ providedIn: 'root' })
export class RwPickedBatchService extends BaseService<CreateRwPickedBatch, RwPickedBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwPickedBatch);
  }
}
