import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateService, Service } from '../../../Shared/Model/-service.model';

@Injectable({ providedIn: 'root' })
export class ServiceService extends BaseService<CreateService, Service> {
  constructor(http: HttpClient) {
    super(http, Configurations.Service);
  }
}
