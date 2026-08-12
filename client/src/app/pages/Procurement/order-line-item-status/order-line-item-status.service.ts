import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateOrderLineItemStatus, OrderLineItemStatus } from '../../../Shared/Model/-order-line-item-status.model';

@Injectable({ providedIn: 'root' })
export class OrderLineItemStatusService extends BaseService<CreateOrderLineItemStatus, OrderLineItemStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.OrderLineItemStatus);
  }
}
