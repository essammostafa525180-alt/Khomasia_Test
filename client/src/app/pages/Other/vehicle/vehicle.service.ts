import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicle, Vehicle } from '../../../Shared/Model/-vehicle.model';

@Injectable({ providedIn: 'root' })
export class VehicleService extends BaseService<CreateVehicle, Vehicle> {
  constructor(http: HttpClient) {
    super(http, Configurations.Vehicle);
  }
}
