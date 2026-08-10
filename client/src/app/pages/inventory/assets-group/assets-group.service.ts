import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetsGroup, AssetsGroup } from '../../../Shared/Model/-assets-group.model';

@Injectable({ providedIn: 'root' })
export class AssetsGroupService extends BaseService<CreateAssetsGroup, AssetsGroup> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetsGroup);
  }
}
