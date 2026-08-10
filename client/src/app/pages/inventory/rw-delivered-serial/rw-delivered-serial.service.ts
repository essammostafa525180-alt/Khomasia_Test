import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwDeliveredSerial, RwDeliveredSerial } from '../../../Shared/Model/-rw-delivered-serial.model';

@Injectable({ providedIn: 'root' })
export class RwDeliveredSerialService extends BaseService<CreateRwDeliveredSerial, RwDeliveredSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwDeliveredSerial);
  }
}
