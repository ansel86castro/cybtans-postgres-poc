using System;
using System.Threading.Tasks;
using Service.Models;
using System.Collections.Generic;

namespace Service.Services
{
	public partial interface ICustomerService 
	{
		
		Task<GetAllCustomerResponse> GetAll(GetAllRequest request);
		
		
		Task<CustomerDto> Get(GetCustomerRequest request);
		
		
		Task<CustomerDto> Create(CreateCustomerRequest request);
		
		
		Task<CustomerDto> Update(UpdateCustomerRequest request);
		
		
		Task Delete(DeleteCustomerRequest request);
		
	}

}
