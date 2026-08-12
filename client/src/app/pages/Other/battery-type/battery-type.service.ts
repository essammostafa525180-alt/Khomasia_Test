import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateBatteryType, BatteryType } from '../../../Shared/Model/-battery-type.model';

@Injectable({ providedIn: 'root' })
export class BatteryTypeService extends BaseService<CreateBatteryType, BatteryType> {
  constructor(http: HttpClient) {
    super(http, Configurations.BatteryType);
  }
}
