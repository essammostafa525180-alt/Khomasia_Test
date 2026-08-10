import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAnnualStockCountItemQuantity, AnnualStockCountItemQuantity } from '../../../Shared/Model/-annual-stock-count-item-quantity.model';

@Injectable({ providedIn: 'root' })
export class AnnualStockCountItemQuantityService extends BaseService<CreateAnnualStockCountItemQuantity, AnnualStockCountItemQuantity> {
  constructor(http: HttpClient) {
    super(http, Configurations.AnnualStockCountItemQuantity);
  }
}
