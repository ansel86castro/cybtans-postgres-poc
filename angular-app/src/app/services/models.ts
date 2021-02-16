
export interface AddressDto {
  street?: string|null;
  number?: string|null;
  city?: string|null;
  state?: string|null;
  country?: string|null;
}


export interface UserDto {
  settings?: any|null;
  firstName?: string|null;
  lastName?: string|null;
  email?: string|null;
  primaryPhone?: string|null;
  secundaryPhone?: string|null;
  address?: AddressDto|null;
  isDeleted: boolean;
  id: number;
  createDate?: string|Date|null;
  updateDate?: string|Date|null;
}


export interface UserFollowingsDto {
  followerId: number;
  followingId: number;
  follower?: UserDto|null;
  following?: UserDto|null;
}


export interface GetAllRequest {
  filter?: string|null;
  sort?: string|null;
  skip?: number|null;
  take?: number|null;
}


export interface GetUserRequest {
  id: number;
}


export interface UpdateUserRequest {
  id: number;
  value?: Partial<UserDto>|null;
}


export interface DeleteUserRequest {
  id: number;
}


export interface GetAllUserResponse {
  items?: UserDto[]|null;
  page: number;
  totalPages: number;
  totalCount: number;
}


export interface CreateUserRequest {
  value?: Partial<UserDto>|null;
}


export interface GetUserFollowingRequest {
  id: number;
  filter?: string|null;
  sort?: string|null;
  skip?: number|null;
  take?: number|null;
}


export interface AddFollowingRequest {
  id: number;
  followingId: number;
}


export interface UnFollowingRequest {
  id: number;
  followingId: number;
}
