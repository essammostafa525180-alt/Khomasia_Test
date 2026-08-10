import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateCustomer, Customer } from '../../../Shared/Model/-customer.model';

@Injectable({ providedIn: 'root' })
export class CustomerService extends BaseService<CreateCustomer, Customer> {
  constructor(http: HttpClient) {
    super(http, Configurations.Customer);
  }
}
