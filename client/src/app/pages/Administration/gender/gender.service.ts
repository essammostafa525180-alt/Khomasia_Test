import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateGender, Gender } from '../../../Shared/Model/-gender.model';

@Injectable({ providedIn: 'root' })
export class GenderService extends BaseService<CreateGender, Gender> {
  constructor(http: HttpClient) {
    super(http, Configurations.Gender);
  }
}
