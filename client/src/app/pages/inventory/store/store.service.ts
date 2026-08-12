import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStore, Store } from '../../../Shared/Model/-store.model';

@Injectable({ providedIn: 'root' })
export class StoreService extends BaseService<CreateStore, Store> {
  constructor(http: HttpClient) {
    super(http, Configurations.Store);
  }
}
