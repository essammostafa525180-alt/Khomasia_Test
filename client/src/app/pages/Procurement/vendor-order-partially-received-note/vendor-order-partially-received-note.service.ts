import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderPartiallyReceivedNote, VendorOrderPartiallyReceivedNote } from '../../../Shared/Model/-vendor-order-partially-received-note.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderPartiallyReceivedNoteService extends BaseService<CreateVendorOrderPartiallyReceivedNote, VendorOrderPartiallyReceivedNote> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderPartiallyReceivedNote);
  }
}
