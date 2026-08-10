import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateMaterialGroup, MaterialGroup } from '../../../Shared/Model/-material-group.model';

@Injectable({ providedIn: 'root' })
export class MaterialGroupService extends BaseService<CreateMaterialGroup, MaterialGroup> {
  constructor(http: HttpClient) {
    super(http, Configurations.MaterialGroup);
  }
}
