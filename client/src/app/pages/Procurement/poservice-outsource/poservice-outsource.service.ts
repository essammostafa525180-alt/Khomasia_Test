import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceOutsource, PoserviceOutsource } from '../../../Shared/Model/-poservice-outsource.model';

@Injectable({ providedIn: 'root' })
export class PoserviceOutsourceService extends BaseService<CreatePoserviceOutsource, PoserviceOutsource> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceOutsource);
  }
}
