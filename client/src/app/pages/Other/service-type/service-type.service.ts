import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateServiceType, ServiceType } from '../../../Shared/Model/-service-type.model';

@Injectable({ providedIn: 'root' })
export class ServiceTypeService extends BaseService<CreateServiceType, ServiceType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ServiceType);
  }
}
