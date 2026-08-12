import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateEquipmentCode, EquipmentCode } from '../../../Shared/Model/-equipment-code.model';

@Injectable({ providedIn: 'root' })
export class EquipmentCodeService extends BaseService<CreateEquipmentCode, EquipmentCode> {
  constructor(http: HttpClient) {
    super(http, Configurations.EquipmentCode);
  }
}
