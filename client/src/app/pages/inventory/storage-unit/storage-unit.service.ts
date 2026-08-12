import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateStorageUnit, StorageUnit } from '../../../Shared/Model/-storage-unit.model';

@Injectable({ providedIn: 'root' })
export class StorageUnitService extends BaseService<CreateStorageUnit, StorageUnit> {
  constructor(http: HttpClient) {
    super(http, Configurations.StorageUnit);
  }
}
