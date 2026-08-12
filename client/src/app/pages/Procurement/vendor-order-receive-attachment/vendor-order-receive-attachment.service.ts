import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceiveAttachment, VendorOrderReceiveAttachment } from '../../../Shared/Model/-vendor-order-receive-attachment.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderReceiveAttachmentService extends BaseService<CreateVendorOrderReceiveAttachment, VendorOrderReceiveAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceiveAttachment);
  }
}
