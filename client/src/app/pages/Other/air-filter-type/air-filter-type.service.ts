import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAirFilterType, AirFilterType } from '../../../Shared/Model/-air-filter-type.model';

@Injectable({ providedIn: 'root' })
export class AirFilterTypeService extends BaseService<CreateAirFilterType, AirFilterType> {
  constructor(http: HttpClient) {
    super(http, Configurations.AirFilterType);
  }
}
