import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStockCountPlanType, StockCountPlanType } from '../../../Shared/Model/-stock-count-plan-type.model';

@Injectable({ providedIn: 'root' })
export class StockCountPlanTypeService extends BaseService<CreateStockCountPlanType, StockCountPlanType> {
  constructor(http: HttpClient) {
    super(http, Configurations.StockCountPlanType);
  }
}
