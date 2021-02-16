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

export type Fetch = (input: RequestInfo, init?: RequestInit)=> Promise<Response>;
export type ErrorInfo = {status:number, statusText:string, text: string };

export interface ServiceOptions{
    baseUrl:string;
}

class BaseServiceService {
    protected _options:ServiceOptions;
    protected _fetch:Fetch;    

    constructor(fetch:Fetch, options:ServiceOptions){
        this._fetch = fetch;
        this._options = options;
    }

    protected getQueryString(data:any): string|undefined {
        if(!data)
            return '';
        let args = [];
        for (let key in data) {
            if (data.hasOwnProperty(key)) {                
                let element = data[key];
                if(element !== undefined && element !== null && element !== ''){
                    if(element instanceof Array){
                        element.forEach(e=> args.push(key + '=' + encodeURIComponent(e instanceof Date ? e.toJSON(): e)));
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

    protected getFormData(data:any): FormData {
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

    protected getObject<T>(response:Response): Promise<T>{
        let status = response.status;
        if(status >= 200 && status < 300 ){            
            return response.json();
        }     
        return response.text().then((text) => Promise.reject<T>({  status, statusText:response.statusText, text }));        
    }

    protected getBlob(response:Response): Promise<Response>{
        let status = response.status;        

        if(status >= 200 && status < 300 ){             
            return Promise.resolve(response);
        }
        return response.text().then((text) => Promise.reject<Response>({  status, statusText:response.statusText, text }));
    }

    protected ensureSuccess(response:Response): Promise<ErrorInfo|void>{
        let status = response.status;
        if(status < 200 || status >= 300){
            return response.text().then((text) => Promise.reject<ErrorInfo>({  status, statusText:response.statusText, text }));        
        }
        return Promise.resolve();
    }
}


export class UserService extends BaseServiceService {  

    constructor(fetch:Fetch, options:ServiceOptions){
        super(fetch, options);        
    }
    
    getFollowing(request:GetUserFollowingRequest) : Promise<GetAllUserResponse> {
    	let options:RequestInit = { method: 'GET', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}/following`+this.getQueryString({ filter: request.filter,sort: request.sort,skip: request.skip,take: request.take});
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    getFollowed(request:GetUserFollowingRequest) : Promise<GetAllUserResponse> {
    	let options:RequestInit = { method: 'GET', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}/followed`+this.getQueryString({ filter: request.filter,sort: request.sort,skip: request.skip,take: request.take});
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    addFollowing(request:AddFollowingRequest) : Promise<UserDto> {
    	let options:RequestInit = { method: 'POST', headers: { Accept: 'application/json', 'Content-Type': 'application/json' }};
    	options.body = JSON.stringify(request);
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}/following`;
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    removeFollowing(request:UnFollowingRequest) : Promise<ErrorInfo|void> {
    	let options:RequestInit = { method: 'DELETE', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}/following/${request.followingId}`;
    	return this._fetch(endpoint, options).then((response:Response) => this.ensureSuccess(response));
    }
    
    getAll(request:GetAllRequest) : Promise<GetAllUserResponse> {
    	let options:RequestInit = { method: 'GET', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User`+this.getQueryString(request);
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    get(request:GetUserRequest) : Promise<UserDto> {
    	let options:RequestInit = { method: 'GET', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}`;
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    create(request:CreateUserRequest) : Promise<UserDto> {
    	let options:RequestInit = { method: 'POST', headers: { Accept: 'application/json', 'Content-Type': 'application/json' }};
    	options.body = JSON.stringify(request);
    	let endpoint = this._options.baseUrl+`/api/User`;
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    update(request:UpdateUserRequest) : Promise<UserDto> {
    	let options:RequestInit = { method: 'PUT', headers: { Accept: 'application/json', 'Content-Type': 'application/json' }};
    	options.body = JSON.stringify(request);
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}`;
    	return this._fetch(endpoint, options).then((response:Response) => this.getObject(response));
    }
    
    delete(request:DeleteUserRequest) : Promise<ErrorInfo|void> {
    	let options:RequestInit = { method: 'DELETE', headers: { Accept: 'application/json' }};
    	let endpoint = this._options.baseUrl+`/api/User/${request.id}`;
    	return this._fetch(endpoint, options).then((response:Response) => this.ensureSuccess(response));
    }

}
