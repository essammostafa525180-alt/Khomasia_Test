import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAllowedCompany, AllowedCompany } from '../../../Shared/Model/-allowed-company.model';

@Injectable({ providedIn: 'root' })
export class AllowedCompanyService extends BaseService<CreateAllowedCompany, AllowedCompany> {
  constructor(http: HttpClient) {
    super(http, Configurations.AllowedCompany);
  }
}
