import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSalesInvoice, SalesInvoice } from '../../../Shared/Model/-sales-invoice.model';

@Injectable({ providedIn: 'root' })
export class SalesInvoiceService extends BaseService<CreateSalesInvoice, SalesInvoice> {
  constructor(http: HttpClient) {
    super(http, Configurations.SalesInvoice);
  }
}
