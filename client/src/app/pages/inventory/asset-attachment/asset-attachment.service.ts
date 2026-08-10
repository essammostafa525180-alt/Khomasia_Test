import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetAttachment, AssetAttachment } from '../../../Shared/Model/-asset-attachment.model';

@Injectable({ providedIn: 'root' })
export class AssetAttachmentService extends BaseService<CreateAssetAttachment, AssetAttachment> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetAttachment);
  }
}
