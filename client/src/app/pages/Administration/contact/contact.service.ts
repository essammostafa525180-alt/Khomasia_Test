import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateContact, Contact } from '../../../Shared/Model/-contact.model';

@Injectable({ providedIn: 'root' })
export class ContactService extends BaseService<CreateContact, Contact> {
  constructor(http: HttpClient) {
    super(http, Configurations.Contact);
  }
}
