import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRack, Rack } from '../../../Shared/Model/-rack.model';

@Injectable({ providedIn: 'root' })
export class RackService extends BaseService<CreateRack, Rack> {
  constructor(http: HttpClient) {
    super(http, Configurations.Rack);
  }
}
