import { Injectable } from '@angular/core';
import { CreateInventoryItem, InventoryItem } from '../../Shared/Model/inventory-item.model';
import { HttpClient } from '@angular/common/http';
import { Configurations } from '../../Configurations/config';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})

export class AhmedService extends BaseService<CreateInventoryItem, InventoryItem> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItem);
  }
}