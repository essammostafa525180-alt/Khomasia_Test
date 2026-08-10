import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceType, PoserviceType } from '../../../Shared/Model/-poservice-type.model';

@Injectable({ providedIn: 'root' })
export class PoserviceTypeService extends BaseService<CreatePoserviceType, PoserviceType> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceType);
  }
}
