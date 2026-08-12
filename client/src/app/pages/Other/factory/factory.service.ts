import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateFactory, Factory } from '../../../Shared/Model/-factory.model';

@Injectable({ providedIn: 'root' })
export class FactoryService extends BaseService<CreateFactory, Factory> {
  constructor(http: HttpClient) {
    super(http, Configurations.Factory);
  }
}
