import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleOption, VehicleOption } from '../../../Shared/Model/-vehicle-option.model';

@Injectable({ providedIn: 'root' })
export class VehicleOptionService extends BaseService<CreateVehicleOption, VehicleOption> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleOption);
  }
}
