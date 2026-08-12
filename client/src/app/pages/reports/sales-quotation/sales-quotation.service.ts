import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSalesQuotation, SalesQuotation } from '../../../Shared/Model/-sales-quotation.model';

@Injectable({ providedIn: 'root' })
export class SalesQuotationService extends BaseService<CreateSalesQuotation, SalesQuotation> {
  constructor(http: HttpClient) {
    super(http, Configurations.SalesQuotation);
  }
}
