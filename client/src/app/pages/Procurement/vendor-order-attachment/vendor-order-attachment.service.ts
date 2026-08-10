import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderAttachment, VendorOrderAttachment } from '../../../Shared/Model/-vendor-order-attachment.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderAttachmentService extends BaseService<CreateVendorOrderAttachment, VendorOrderAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderAttachment);
  }
}
