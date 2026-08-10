import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventroyItemRequestWithdraw, InventroyItemRequestWithdraw } from '../../../Shared/Model/-inventroy-item-request-withdraw.model';

@Injectable({ providedIn: 'root' })
export class InventroyItemRequestWithdrawService extends BaseService<CreateInventroyItemRequestWithdraw, InventroyItemRequestWithdraw> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventroyItemRequestWithdraw);
  }
}
