import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders, HttpEvent, HttpResponse } from '@angular/common/http';
import { 
  GetAllRequest,
  GetAllUserResponse,
  GetUserRequest,
  UserDto,
  CreateUserRequest,
  UpdateUserRequest,
  DeleteUserRequest,
  GetUserFollowingRequest,
  AddFollowingRequest,
  UnFollowingRequest,
 } from './models';

function getQueryString(data:any): string|undefined {
  if(!data) return '';
  let args = [];
  for (let key in data) {
      if (data.hasOwnProperty(key)) {                
          let element = data[key];
          if(element !== undefined && element !== null && element !== ''){
              if(element instanceof Array){
                  element.forEach(e=>args.push(key + '=' + encodeURIComponent(e instanceof Date ? e.toJSON(): e)) );
              }else if(element instanceof Date){
                  args.push(key + '=' + encodeURIComponent(element.toJSON()));
              }else{
                  args.push(key + '=' + encodeURIComponent(element));
              }
          }
      }
  }

  return args.length > 0 ? '?' + args.join('&') : '';
}


function getFormData(data:any): FormData {
    let form = new FormData();
    if(!data)
        return form;
        
    for (let key in data) {
        if (data.hasOwnProperty(key)) {                
            let value = data[key];
            if(value !== undefined && value !== null && value !== ''){
                if (value instanceof Date){
                    form.append(key, value.toJSON());
                }else if(typeof value === 'number' || typeof value === 'bigint' || typeof value === 'boolean'){
                    form.append(key, value.toString());
                }else if(value instanceof File){
                    form.append(key, value, value.name);
                }else if(value instanceof Blob){
                    form.append(key, value, 'blob');
                }else if(typeof value ==='string'){
                    form.append(key, value);
                }else{
                    throw new Error(`value of ${key} is not supported for multipart/form-data upload`);
                }
            }
        }
    }
    return form;
}


@Injectable({
  providedIn: 'root',
})
export class UserService {

    constructor(private http: HttpClient) {}
    
    getFollowing(request: GetUserFollowingRequest): Observable<GetAllUserResponse> {
      return this.http.get<GetAllUserResponse>(`/api/User/${request.id}/following${ getQueryString({ filter: request.filter, sort: request.sort, skip: request.skip, take: request.take }) }`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }
    
    getFollowed(request: GetUserFollowingRequest): Observable<GetAllUserResponse> {
      return this.http.get<GetAllUserResponse>(`/api/User/${request.id}/followed${ getQueryString({ filter: request.filter, sort: request.sort, skip: request.skip, take: request.take }) }`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }
    
    addFollowing(request: AddFollowingRequest): Observable<UserDto> {
      return this.http.post<UserDto>(`/api/User/${request.id}/following`, request, {
          headers: new HttpHeaders({ Accept: 'application/json', 'Content-Type': 'application/json' }),
      });
    }
    
    removeFollowing(request: UnFollowingRequest): Observable<{}> {
      return this.http.delete<{}>(`/api/User/${request.id}/following/${request.followingId}`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }
    
    getAll(request: GetAllRequest): Observable<GetAllUserResponse> {
      return this.http.get<GetAllUserResponse>(`/api/User${ getQueryString(request) }`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }
    
    get(request: GetUserRequest): Observable<UserDto> {
      return this.http.get<UserDto>(`/api/User/${request.id}`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }
    
    create(request: CreateUserRequest): Observable<UserDto> {
      return this.http.post<UserDto>(`/api/User`, request, {
          headers: new HttpHeaders({ Accept: 'application/json', 'Content-Type': 'application/json' }),
      });
    }
    
    update(request: UpdateUserRequest): Observable<UserDto> {
      return this.http.put<UserDto>(`/api/User/${request.id}`, request, {
          headers: new HttpHeaders({ Accept: 'application/json', 'Content-Type': 'application/json' }),
      });
    }
    
    delete(request: DeleteUserRequest): Observable<{}> {
      return this.http.delete<{}>(`/api/User/${request.id}`, {
          headers: new HttpHeaders({ Accept: 'application/json' }),
      });
    }

}
