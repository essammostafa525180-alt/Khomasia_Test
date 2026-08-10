import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePurchaseOrderService, PurchaseOrderService } from '../../../Shared/Model/-purchase-order-service.model';

@Injectable({ providedIn: 'root' })
export class PurchaseOrderServiceService extends BaseService<CreatePurchaseOrderService, PurchaseOrderService> {
  constructor(http: HttpClient) {
    super(http, Configurations.PurchaseOrderService);
  }
}
