import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateItemBalanceStatus, ItemBalanceStatus } from '../../../Shared/Model/-item-balance-status.model';

@Injectable({ providedIn: 'root' })
export class ItemBalanceStatusService extends BaseService<CreateItemBalanceStatus, ItemBalanceStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ItemBalanceStatus);
  }
}
