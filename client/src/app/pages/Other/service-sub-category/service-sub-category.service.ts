import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateServiceSubCategory, ServiceSubCategory } from '../../../Shared/Model/-service-sub-category.model';

@Injectable({ providedIn: 'root' })
export class ServiceSubCategoryService extends BaseService<CreateServiceSubCategory, ServiceSubCategory> {
  constructor(http: HttpClient) {
    super(http, Configurations.ServiceSubCategory);
  }
}
