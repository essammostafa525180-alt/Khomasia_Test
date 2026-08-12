import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateLocation, Location } from '../../../Shared/Model/-location.model';

@Injectable({ providedIn: 'root' })
export class LocationService extends BaseService<CreateLocation, Location> {
  constructor(http: HttpClient) {
    super(http, Configurations.Location);
  }
}
