import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfereAttachment, InventoryTransfereAttachment } from '../../../Shared/Model/-inventory-transfere-attachment.model';

@Injectable({ providedIn: 'root' })
export class InventoryTransfereAttachmentService extends BaseService<CreateInventoryTransfereAttachment, InventoryTransfereAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfereAttachment);
  }
}
