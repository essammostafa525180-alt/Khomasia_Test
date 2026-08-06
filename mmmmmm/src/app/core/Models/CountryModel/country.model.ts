export interface CountryModel {
  id: number;
  name: string;
  code: string;
}

export interface CreateCountryModel {
  name: string;
  code: string;
}

export interface UpdateCountryModel {
  name: string;
  code: string;
}
