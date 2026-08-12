import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetCountIssueStatus, AssetCountIssueStatus } from '../../../Shared/Model/-asset-count-issue-status.model';

@Injectable({ providedIn: 'root' })
export class AssetCountIssueStatusService extends BaseService<CreateAssetCountIssueStatus, AssetCountIssueStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetCountIssueStatus);
  }
}
