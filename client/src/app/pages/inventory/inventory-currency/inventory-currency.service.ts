import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryCurrency, InventoryCurrency } from '../../../Shared/Model/-inventory-currency.model';

@Injectable({ providedIn: 'root' })
export class InventoryCurrencyService extends BaseService<CreateInventoryCurrency, InventoryCurrency> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryCurrency);
  }
}
