
/** Customer Entity */
export interface CustomerDto {
  /** Customer's Name */
  name: string;
  /** Customer's FirstLastName */
  firstLastName?: string|null;
  /** Customer's SecondLastName */
  secondLastName?: string|null;
  /** Customer's Profile Id, can be null */
  customerProfileId?: string|null;
  customerProfile?: CustomerProfileDto|null;
  orders?: OrderDto[]|null;
  id: string;
  createDate?: string|Date|null;
  updateDate?: string|Date|null;
}


export interface CustomerProfileDto {
  name?: string|null;
  id: string;
  createDate?: string|Date|null;
  updateDate?: string|Date|null;
}


export interface OrderDto {
  description?: string|null;
  customerId: string;
  orderStateId: number;
  orderType: OrderTypeEnum;
  orderState?: OrderStateDto|null;
  items?: OrderItemDto[]|null;
  id: string;
  createDate?: string|Date|null;
  updateDate?: string|Date|null;
}



/** Enum Type Description */
export enum OrderTypeEnum {
  /** Default */
  default = 0,
  /** Normal */
  normal = 1,
  /** Shipping */
  shipping = 2,
}



export interface OrderStateDto {
  name?: string|null;
  id: number;
}


export interface OrderItemDto {
  productName?: string|null;
  price: number;
  discount?: number|null;
  orderId: string;
  id: string;
}


export interface GetAllRequest {
  filter?: string|null;
  sort?: string|null;
  skip?: number|null;
  take?: number|null;
}


export interface GetCustomerRequest {
  id: string;
}


export interface UpdateCustomerRequest {
  id: string;
  value?: Partial<CustomerDto>|null;
}


export interface DeleteCustomerRequest {
  id: string;
}


export interface GetAllCustomerResponse {
  items?: CustomerDto[]|null;
  page: number;
  totalPages: number;
  totalCount: number;
}


export interface CreateCustomerRequest {
  value?: Partial<CustomerDto>|null;
}


export interface GetOrderRequest {
  id: string;
}


export interface UpdateOrderRequest {
  id: string;
  value?: Partial<OrderDto>|null;
}


export interface DeleteOrderRequest {
  id: string;
}


export interface GetAllOrderResponse {
  items?: OrderDto[]|null;
  page: number;
  totalPages: number;
  totalCount: number;
}


export interface CreateOrderRequest {
  value?: Partial<OrderDto>|null;
}


export interface GetOrderStateRequest {
  id: number;
}


export interface UpdateOrderStateRequest {
  id: number;
  value?: Partial<OrderStateDto>|null;
}


export interface DeleteOrderStateRequest {
  id: number;
}


export interface GetAllOrderStateResponse {
  items?: OrderStateDto[]|null;
  page: number;
  totalPages: number;
  totalCount: number;
}


export interface CreateOrderStateRequest {
  value?: Partial<OrderStateDto>|null;
}
