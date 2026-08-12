import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountIssue, AssetCountIssue } from '../../../Shared/Model/-asset-count-issue.model';

@Injectable({ providedIn: 'root' })
export class AssetIssueRequestService extends BaseService<CreateAssetCountIssue, AssetCountIssue> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountIssue);
  }
}
