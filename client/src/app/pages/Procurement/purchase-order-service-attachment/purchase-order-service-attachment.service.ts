import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePurchaseOrderServiceAttachment, PurchaseOrderServiceAttachment } from '../../../Shared/Model/-purchase-order-service-attachment.model';

@Injectable({ providedIn: 'root' })
export class PurchaseOrderServiceAttachmentService extends BaseService<CreatePurchaseOrderServiceAttachment, PurchaseOrderServiceAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.PurchaseOrderServiceAttachment);
  }
}
