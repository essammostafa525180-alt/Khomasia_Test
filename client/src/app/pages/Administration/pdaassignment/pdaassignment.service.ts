import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePdaassignment, Pdaassignment } from '../../../Shared/Model/-pdaassignment.model';

@Injectable({ providedIn: 'root' })
export class PdaassignmentService extends BaseService<CreatePdaassignment, Pdaassignment> {
  constructor(http: HttpClient) {
    super(http, Configurations.Pdaassignment);
  }
}
