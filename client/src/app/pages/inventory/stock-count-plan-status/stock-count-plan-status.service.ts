import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStockCountPlanStatus, StockCountPlanStatus } from '../../../Shared/Model/-stock-count-plan-status.model';

@Injectable({ providedIn: 'root' })
export class StockCountPlanStatusService extends BaseService<CreateStockCountPlanStatus, StockCountPlanStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.StockCountPlanStatus);
  }
}
