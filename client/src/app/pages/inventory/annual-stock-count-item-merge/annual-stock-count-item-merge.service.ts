import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAnnualStockCountItemMerge, AnnualStockCountItemMerge } from '../../../Shared/Model/-annual-stock-count-item-merge.model';

@Injectable({ providedIn: 'root' })
export class AnnualStockCountItemMergeService extends BaseService<CreateAnnualStockCountItemMerge, AnnualStockCountItemMerge> {
  constructor(http: HttpClient) {
    super(http, Configurations.AnnualStockCountItemMerge);
  }
}
