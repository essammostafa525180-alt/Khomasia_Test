import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssetsType, AssetsType } from '../../../Shared/Model/-assets-type.model';

@Injectable({ providedIn: 'root' })
export class AssetsTypeService extends BaseService<CreateAssetsType, AssetsType> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssetsType);
  }
}
