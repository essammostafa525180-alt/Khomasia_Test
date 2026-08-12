import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVehicleStatus, VehicleStatus } from '../../../Shared/Model/-vehicle-status.model';

@Injectable({ providedIn: 'root' })
export class VehicleStatusService extends BaseService<CreateVehicleStatus, VehicleStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.VehicleStatus);
  }
}
