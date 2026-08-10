import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecProperty, SecProperty } from '../../../Shared/Model/-sec-property.model';

@Injectable({ providedIn: 'root' })
export class SecPropertyService extends BaseService<CreateSecProperty, SecProperty> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecProperty);
  }
}
