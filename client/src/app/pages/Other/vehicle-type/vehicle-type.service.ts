import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleType, VehicleType } from '../../../Shared/Model/-vehicle-type.model';

@Injectable({ providedIn: 'root' })
export class VehicleTypeService extends BaseService<CreateVehicleType, VehicleType> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleType);
  }
}
