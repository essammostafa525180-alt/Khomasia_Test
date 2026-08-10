import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleColor, VehicleColor } from '../../../Shared/Model/-vehicle-color.model';

@Injectable({ providedIn: 'root' })
export class VehicleColorService extends BaseService<CreateVehicleColor, VehicleColor> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleColor);
  }
}
