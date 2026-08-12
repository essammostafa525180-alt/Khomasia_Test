import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAnnualStockCount, AnnualStockCount } from '../../../Shared/Model/-annual-stock-count.model';

@Injectable({ providedIn: 'root' })
export class AnnualStockCountService extends BaseService<CreateAnnualStockCount, AnnualStockCount> {
  constructor(http: HttpClient) {
    super(http, Configurations.AnnualStockCount);
  }
}
