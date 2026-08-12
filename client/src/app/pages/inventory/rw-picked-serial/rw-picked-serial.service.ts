import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwPickedSerial, RwPickedSerial } from '../../../Shared/Model/-rw-picked-serial.model';

@Injectable({ providedIn: 'root' })
export class RwPickedSerialService extends BaseService<CreateRwPickedSerial, RwPickedSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwPickedSerial);
  }
}
