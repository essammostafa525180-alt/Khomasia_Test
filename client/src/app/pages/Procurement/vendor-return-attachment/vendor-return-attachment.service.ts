import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturnAttachment, VendorReturnAttachment } from '../../../Shared/Model/-vendor-return-attachment.model';

@Injectable({ providedIn: 'root' })
export class VendorReturnAttachmentService extends BaseService<CreateVendorReturnAttachment, VendorReturnAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturnAttachment);
  }
}
