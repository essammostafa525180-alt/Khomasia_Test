import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderQualityAttachment, VendorOrderQualityAttachment } from '../../../Shared/Model/-vendor-order-quality-attachment.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderQualityAttachmentService extends BaseService<CreateVendorOrderQualityAttachment, VendorOrderQualityAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderQualityAttachment);
  }
}
