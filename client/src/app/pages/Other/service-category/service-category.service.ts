import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateServiceCategory, ServiceCategory } from '../../../Shared/Model/-service-category.model';

@Injectable({ providedIn: 'root' })
export class ServiceCategoryService extends BaseService<CreateServiceCategory, ServiceCategory> {
  constructor(http: HttpClient) {
    super(http, Configurations.ServiceCategory);
  }
}
