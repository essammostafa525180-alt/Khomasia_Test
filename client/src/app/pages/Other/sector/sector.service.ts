import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSector, Sector } from '../../../Shared/Model/-sector.model';

@Injectable({ providedIn: 'root' })
export class SectorService extends BaseService<CreateSector, Sector> {
  constructor(http: HttpClient) {
    super(http, Configurations.Sector);
  }
}
