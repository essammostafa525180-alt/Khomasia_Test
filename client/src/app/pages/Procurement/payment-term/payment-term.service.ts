import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePaymentTerm, PaymentTerm } from '../../../Shared/Model/-payment-term.model';

@Injectable({ providedIn: 'root' })
export class PaymentTermService extends BaseService<CreatePaymentTerm, PaymentTerm> {
  constructor(http: HttpClient) {
    super(http, Configurations.PaymentTerm);
  }
}
