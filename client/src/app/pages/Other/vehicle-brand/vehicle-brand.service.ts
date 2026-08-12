import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleBrand, VehicleBrand } from '../../../Shared/Model/-vehicle-brand.model';

@Injectable({ providedIn: 'root' })
export class VehicleBrandService extends BaseService<CreateVehicleBrand, VehicleBrand> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleBrand);
  }
}
