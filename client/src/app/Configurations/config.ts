// Always import the base environment: the CLI swaps in
// environment.development.ts for the development configuration.
import { environment } from "../../environments/environment";


export type ModuleEndpoints = {
  GetAll        : string;
  GetById       : (id: string | number) => string;
  Create        : string;
  Update        : (id: number | string) => string;
  Delete        : (id: number | string) => string;
  LookUp?       : string;
  Search?       : string;
  SearchLookUp? : string;
}


function endPoint(module: string) : ModuleEndpoints {
  return {
    GetAll: `${module}/GetAll`,
    GetById: (id: string | number) => `${module}/GetById/${id}`,
    Create: `${module}/Create`,
    Update: (id: string | number) => `${module}/Update/${id}`,
    Delete: (id: string | number) => `${module}/Delete/${id}`,
    LookUp: `${module}/LookUp`,
    Search: `${module}/Search`,
    SearchLookUp: `${module}/SearchLookUp`,
  };
}

export abstract class Configurations {
  static readonly Url = environment.apiUrl;

  static build(path: string): string {
    return `${Configurations.Url}/${path}`;
  }

  static readonly Test = { ...endPoint('TestDemo') };
  static readonly Country = { ...endPoint('Country') };
  static readonly City = { ...endPoint('City') };
}

