import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStoreKeeper, StoreKeeper } from '../../../Shared/Model/-store-keeper.model';

@Injectable({ providedIn: 'root' })
export class StoreKeeperService extends BaseService<CreateStoreKeeper, StoreKeeper> {
  constructor(http: HttpClient) {
    super(http, Configurations.StoreKeeper);
  }
}
