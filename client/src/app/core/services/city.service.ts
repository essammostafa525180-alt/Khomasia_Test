import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { CreateCityModel, CityModel } from '../Models/CityModel/city.model';
import { HttpClient } from '@angular/common/http';
import { Configurations } from '../../Configurations/config';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CityService extends BaseService<CreateCityModel, CityModel> {
  constructor(http: HttpClient) {
    super(http, Configurations.City);
  }

}
