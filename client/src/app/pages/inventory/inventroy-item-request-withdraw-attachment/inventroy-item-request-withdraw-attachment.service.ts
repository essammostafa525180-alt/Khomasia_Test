import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventroyItemRequestWithdrawAttachment, InventroyItemRequestWithdrawAttachment } from '../../../Shared/Model/-inventroy-item-request-withdraw-attachment.model';

@Injectable({ providedIn: 'root' })
export class InventroyItemRequestWithdrawAttachmentService extends BaseService<CreateInventroyItemRequestWithdrawAttachment, InventroyItemRequestWithdrawAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventroyItemRequestWithdrawAttachment);
  }
}
