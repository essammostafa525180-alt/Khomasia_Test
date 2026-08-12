import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSalesQuotationDetail, SalesQuotationDetail } from '../../../Shared/Model/-sales-quotation-detail.model';

@Injectable({ providedIn: 'root' })
export class SalesQuotationDetailService extends BaseService<CreateSalesQuotationDetail, SalesQuotationDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.SalesQuotationDetail);
  }
}
