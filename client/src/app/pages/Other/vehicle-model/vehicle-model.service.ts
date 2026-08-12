import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleModel, VehicleModel } from '../../../Shared/Model/-vehicle-model.model';

@Injectable({ providedIn: 'root' })
export class VehicleModelService extends BaseService<CreateVehicleModel, VehicleModel> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleModel);
  }
}
