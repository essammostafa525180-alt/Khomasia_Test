import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStoreSequence, StoreSequence } from '../../../Shared/Model/-store-sequence.model';

@Injectable({ providedIn: 'root' })
export class StoreSequenceService extends BaseService<CreateStoreSequence, StoreSequence> {
  constructor(http: HttpClient) {
    super(http, Configurations.StoreSequence);
  }
}
