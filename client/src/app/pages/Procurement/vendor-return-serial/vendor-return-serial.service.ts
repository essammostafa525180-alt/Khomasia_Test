import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturnSerial, VendorReturnSerial } from '../../../Shared/Model/-vendor-return-serial.model';

@Injectable({ providedIn: 'root' })
export class VendorReturnSerialService extends BaseService<CreateVendorReturnSerial, VendorReturnSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturnSerial);
  }
}
