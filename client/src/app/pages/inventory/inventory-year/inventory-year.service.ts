import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryYear, InventoryYear } from '../../../Shared/Model/-inventory-year.model';

@Injectable({ providedIn: 'root' })
export class InventoryYearService extends BaseService<CreateInventoryYear, InventoryYear> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryYear);
  }
}
