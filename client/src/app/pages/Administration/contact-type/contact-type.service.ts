import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateContactType, ContactType } from '../../../Shared/Model/-contact-type.model';

@Injectable({ providedIn: 'root' })
export class ContactTypeService extends BaseService<CreateContactType, ContactType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ContactType);
  }
}
