import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssignCostCenterToSector, AssignCostCenterToSector } from '../../../Shared/Model/-assign-cost-center-to-sector.model';

@Injectable({ providedIn: 'root' })
export class AssignCostCenterToSectorService extends BaseService<CreateAssignCostCenterToSector, AssignCostCenterToSector> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssignCostCenterToSector);
  }
}
