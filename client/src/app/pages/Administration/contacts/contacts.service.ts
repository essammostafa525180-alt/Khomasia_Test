import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateContacts, Contacts } from '../../../Shared/Model/-contacts.model';

@Injectable({ providedIn: 'root' })
export class ContactsService extends BaseService<CreateContacts, Contacts> {
  constructor(http: HttpClient) {
    super(http, Configurations.Contacts);
  }
}
