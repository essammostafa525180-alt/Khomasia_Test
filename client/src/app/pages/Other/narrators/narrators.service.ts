import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNarrators, Narrators } from '../../../Shared/Model/-narrators.model';

@Injectable({ providedIn: 'root' })
export class NarratorsService extends BaseService<CreateNarrators, Narrators> {
  constructor(http: HttpClient) {
    super(http, Configurations.Narrators);
  }
}
