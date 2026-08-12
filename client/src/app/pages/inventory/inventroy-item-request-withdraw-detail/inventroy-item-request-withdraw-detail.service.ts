import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventroyItemRequestWithdrawDetail, InventroyItemRequestWithdrawDetail } from '../../../Shared/Model/-inventroy-item-request-withdraw-detail.model';

@Injectable({ providedIn: 'root' })
export class InventroyItemRequestWithdrawDetailService extends BaseService<CreateInventroyItemRequestWithdrawDetail, InventroyItemRequestWithdrawDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventroyItemRequestWithdrawDetail);
  }
}
