import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceiveSerial, VendorOrderReceiveSerial } from '../../../Shared/Model/-vendor-order-receive-serial.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderReceiveSerialService extends BaseService<CreateVendorOrderReceiveSerial, VendorOrderReceiveSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceiveSerial);
  }
}
