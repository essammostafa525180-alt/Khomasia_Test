// Generated from WebApi/Controllers/UserController.cs + Domain entity.

export interface ApiResult<T> {
  isSuccess: boolean;
  data: T;
  errorMessage: string | null;
}

export interface PagedResult<T> {
  items: T[];
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  nextPage: boolean;
}

export interface GetAllUserParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface User {
  id: number;
  updatedOn?: Date | null;
  code?: string | null;
  name?: string | null;
  userId?: string | null;
  password?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  contact?: number | null;
  active?: boolean | null;
  ouid?: number | null;
  nameAr?: string | null;
  branchId?: number | null;
  lastLogin?: Date | null;
  forcePasswordChange?: boolean | null;
  employeeId?: number | null;
  maxDiscount?: number | null;
  passwordCreationDate?: Date | null;
  fullName?: string | null;
  profilePicture?: any[] | null;
  adUserId?: number | null;
  isPda?: boolean | null;
  singleSession?: number | null;
  timestamp: any[];
  adUser?: any | null;
  employee?: any | null;
  ou?: any | null;
}

export interface CreateUser {
  id: number;
  updatedOn?: Date | null;
  code?: string | null;
  name?: string | null;
  userId?: string | null;
  password?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  contact?: number | null;
  active?: boolean | null;
  ouid?: number | null;
  nameAr?: string | null;
  branchId?: number | null;
  lastLogin?: Date | null;
  forcePasswordChange?: boolean | null;
  employeeId?: number | null;
  maxDiscount?: number | null;
  passwordCreationDate?: Date | null;
  fullName?: string | null;
  profilePicture?: any[] | null;
  adUserId?: number | null;
  isPda?: boolean | null;
  singleSession?: number | null;
  timestamp: any[];
  adUser?: any | null;
  employee?: any | null;
  ou?: any | null;
}

export interface UserPayload {
  updatedOn?: Date | null;
  code?: string | null;
  name?: string | null;
  userId?: string | null;
  password?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  contact?: number | null;
  active?: boolean | null;
  ouid?: number | null;
  nameAr?: string | null;
  branchId?: number | null;
  lastLogin?: Date | null;
  forcePasswordChange?: boolean | null;
  employeeId?: number | null;
  maxDiscount?: number | null;
  passwordCreationDate?: Date | null;
  fullName?: string | null;
  profilePicture?: any[] | null;
  adUserId?: number | null;
  isPda?: boolean | null;
  singleSession?: number | null;
  timestamp: any[];
  adUser?: any | null;
  employee?: any | null;
  ou?: any | null;
}

export interface User extends UserPayload {
  id: number;
  isDeleted: boolean;
}

