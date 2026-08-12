import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateServiceMainCategory, ServiceMainCategory } from '../../../Shared/Model/-service-main-category.model';

@Injectable({ providedIn: 'root' })
export class ServiceMainCategoryService extends BaseService<CreateServiceMainCategory, ServiceMainCategory> {
  constructor(http: HttpClient) {
    super(http, Configurations.ServiceMainCategory);
  }
}
