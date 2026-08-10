import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSalesInvoiceItem, SalesInvoiceItem } from '../../../Shared/Model/-sales-invoice-item.model';

@Injectable({ providedIn: 'root' })
export class SalesInvoiceItemService extends BaseService<CreateSalesInvoiceItem, SalesInvoiceItem> {
  constructor(http: HttpClient) {
    super(http, Configurations.SalesInvoiceItem);
  }
}
