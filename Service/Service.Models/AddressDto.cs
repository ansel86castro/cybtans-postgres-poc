using System;
using Cybtans.Serialization;

namespace Service.Models
{
	public partial class AddressDto : IReflectorMetadataProvider
	{
		private static readonly AddressDtoAccesor __accesor = new AddressDtoAccesor();
		
		public string Street {get; set;}
		
		public string Number {get; set;}
		
		public string City {get; set;}
		
		public string State {get; set;}
		
		public string Country {get; set;}
		
		public IReflectorMetadata GetAccesor()
		{
			return __accesor;
		}
	}
	
	
	public sealed class AddressDtoAccesor : IReflectorMetadata
	{
		public const int Street = 1;
		public const int Number = 2;
		public const int City = 3;
		public const int State = 4;
		public const int Country = 5;
		private readonly int[] _props = new []
		{
			Street,Number,City,State,Country
		};
		
		public int[] GetPropertyCodes() => _props;
		
		public string GetPropertyName(int propertyCode)
		{
		    return propertyCode switch
		    {
		       Street => "Street",
		       Number => "Number",
		       City => "City",
		       State => "State",
		       Country => "Country",
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public int GetPropertyCode(string propertyName)
		{
		    return propertyName switch
		    {
		        "Street" => Street,
		        "Number" => Number,
		        "City" => City,
		        "State" => State,
		        "Country" => Country,
		
		        _ => -1,
		    };
		}
		
		public Type GetPropertyType(int propertyCode)
		{
		    return propertyCode switch
		    {
		        Street => typeof(string),
		        Number => typeof(string),
		        City => typeof(string),
		        State => typeof(string),
		        Country => typeof(string),
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		       
		public object GetValue(object target, int propertyCode)
		{
		    AddressDto obj = (AddressDto)target;
		    return propertyCode switch
		    {
		        Street => obj.Street,
		        Number => obj.Number,
		        City => obj.City,
		        State => obj.State,
		        Country => obj.Country,
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public void SetValue(object target, int propertyCode, object value)
		{
		    AddressDto obj = (AddressDto)target;
		    switch (propertyCode)
		    {
		        case Street:  obj.Street = (string)value;break;
		        case Number:  obj.Number = (string)value;break;
		        case City:  obj.City = (string)value;break;
		        case State:  obj.State = (string)value;break;
		        case Country:  obj.Country = (string)value;break;
		
		        default: throw new InvalidOperationException("property code not supported");
		    }
		}
	
	}

}
