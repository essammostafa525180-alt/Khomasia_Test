import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { CreateTestModel, TestModel } from '../Models/TestModel/test.model';
import { HttpClient } from '@angular/common/http';
import { Configurations } from '../../Configurations/config';

@Injectable({
  providedIn: 'root'
})
export class TestDemoService extends BaseService<CreateTestModel,TestModel> 

  {
      constructor(http: HttpClient) {

    super(http, Configurations.Test);
  }



}

