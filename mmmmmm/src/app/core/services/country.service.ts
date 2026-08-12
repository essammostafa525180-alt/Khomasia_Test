import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { CreateCountryModel, CountryModel } from '../Models/CountryModel/country.model';
import { HttpClient } from '@angular/common/http';
import { Configurations } from '../../Configurations/config';
import { Observable, of } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CountryService extends BaseService<CreateCountryModel, CountryModel> {
  constructor(http: HttpClient) {
    super(http, Configurations.Country);
  }


}

