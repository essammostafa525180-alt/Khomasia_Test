import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssignAssetTypeToAssetGroup, AssignAssetTypeToAssetGroup } from '../../../Shared/Model/-assign-asset-type-to-asset-group.model';

@Injectable({ providedIn: 'root' })
export class AssignAssetTypeToAssetGroupService extends BaseService<CreateAssignAssetTypeToAssetGroup, AssignAssetTypeToAssetGroup> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssignAssetTypeToAssetGroup);
  }
}
