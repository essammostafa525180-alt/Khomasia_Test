import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetItemAttachment, AssetItemAttachment } from '../../../Shared/Model/-asset-item-attachment.model';

@Injectable({ providedIn: 'root' })
export class AssetItemAttachmentService extends BaseService<CreateAssetItemAttachment, AssetItemAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetItemAttachment);
  }
}
