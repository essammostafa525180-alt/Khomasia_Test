import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturnAttachment, InventoryItemReturnAttachment } from '../../../Shared/Model/-inventory-item-return-attachment.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnAttachmentService extends BaseService<CreateInventoryItemReturnAttachment, InventoryItemReturnAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturnAttachment);
  }
}
