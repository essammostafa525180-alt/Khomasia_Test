import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSparePartGroup, SparePartGroup } from '../../../Shared/Model/-spare-part-group.model';

@Injectable({ providedIn: 'root' })
export class SparePartGroupService extends BaseService<CreateSparePartGroup, SparePartGroup> {
  constructor(http: HttpClient) {
    super(http, Configurations.SparePartGroup);
  }
}
