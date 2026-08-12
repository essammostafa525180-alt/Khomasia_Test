import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateChemicalGroup, ChemicalGroup } from '../../../Shared/Model/-chemical-group.model';

@Injectable({ providedIn: 'root' })
export class ChemicalGroupService extends BaseService<CreateChemicalGroup, ChemicalGroup> {
  constructor(http: HttpClient) {
    super(http, Configurations.ChemicalGroup);
  }
}
