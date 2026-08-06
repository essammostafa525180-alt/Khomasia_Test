export interface CityModel {
  id: number;
  name: string;
  countryId: number;
  countryName: string;
}

export interface CreateCityModel {
  name: string;
  countryId: number;
}

export interface UpdateCityModel {
  name: string;
  countryId: number;
}
