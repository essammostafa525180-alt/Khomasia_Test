import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTransfereType, TransfereType } from '../../../Shared/Model/-transfere-type.model';

@Injectable({ providedIn: 'root' })
export class TransfereTypeService extends BaseService<CreateTransfereType, TransfereType> {
  constructor(http: HttpClient) {
    super(http, Configurations.TransfereType);
  }
}
