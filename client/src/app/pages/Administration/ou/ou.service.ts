import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateOu, Ou } from '../../../Shared/Model/-ou.model';

@Injectable({ providedIn: 'root' })
export class OuService extends BaseService<CreateOu, Ou> {
  constructor(http: HttpClient) {
    super(http, Configurations.Ou);
  }
}
