import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateCompany, Company } from '../../../Shared/Model/-company.model';

@Injectable({ providedIn: 'root' })
export class CompanyService extends BaseService<CreateCompany, Company> {
  constructor(http: HttpClient) {
    super(http, Configurations.Company);
  }
}
