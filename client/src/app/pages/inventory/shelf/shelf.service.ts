import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateShelf, Shelf } from '../../../Shared/Model/-shelf.model';

@Injectable({ providedIn: 'root' })
export class ShelfService extends BaseService<CreateShelf, Shelf> {
  constructor(http: HttpClient) {
    super(http, Configurations.Shelf);
  }
}
