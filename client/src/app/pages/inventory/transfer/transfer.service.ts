import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfere, InventoryTransfere } from '../../../Shared/Model/-inventory-transfere.model';

@Injectable({ providedIn: 'root' })
export class TransferService extends BaseService<CreateInventoryTransfere, InventoryTransfere> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfere);
  }
}
