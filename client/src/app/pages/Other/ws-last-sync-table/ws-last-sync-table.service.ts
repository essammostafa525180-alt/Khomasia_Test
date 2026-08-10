import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateWsLastSyncTable, WsLastSyncTable } from '../../../Shared/Model/-ws-last-sync-table.model';

@Injectable({ providedIn: 'root' })
export class WsLastSyncTableService extends BaseService<CreateWsLastSyncTable, WsLastSyncTable> {
  constructor(http: HttpClient) {
    super(http, Configurations.WsLastSyncTable);
  }
}
