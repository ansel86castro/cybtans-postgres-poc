using System;
using Cybtans.Serialization;
using System.Collections.Generic;

namespace Service.Models
{
	public partial class UserDto : IReflectorMetadataProvider
	{
		private static readonly UserDtoAccesor __accesor = new UserDtoAccesor();
		
		public Dictionary<string,string> Settings {get; set;}
		
		public string FirstName {get; set;}
		
		public string LastName {get; set;}
		
		public string Email {get; set;}
		
		public string PrimaryPhone {get; set;}
		
		public string SecundaryPhone {get; set;}
		
		public AddressDto Address {get; set;}
		
		public bool IsDeleted {get; set;}
		
		public int Id {get; set;}
		
		public DateTime? CreateDate {get; set;}
		
		public DateTime? UpdateDate {get; set;}
		
		public IReflectorMetadata GetAccesor()
		{
			return __accesor;
		}
	}
	
	
	public sealed class UserDtoAccesor : IReflectorMetadata
	{
		public const int Settings = 1;
		public const int FirstName = 2;
		public const int LastName = 3;
		public const int Email = 4;
		public const int PrimaryPhone = 5;
		public const int SecundaryPhone = 6;
		public const int Address = 7;
		public const int IsDeleted = 8;
		public const int Id = 9;
		public const int CreateDate = 10;
		public const int UpdateDate = 11;
		private readonly int[] _props = new []
		{
			Settings,FirstName,LastName,Email,PrimaryPhone,SecundaryPhone,Address,IsDeleted,Id,CreateDate,UpdateDate
		};
		
		public int[] GetPropertyCodes() => _props;
		
		public string GetPropertyName(int propertyCode)
		{
		    return propertyCode switch
		    {
		       Settings => "Settings",
		       FirstName => "FirstName",
		       LastName => "LastName",
		       Email => "Email",
		       PrimaryPhone => "PrimaryPhone",
		       SecundaryPhone => "SecundaryPhone",
		       Address => "Address",
		       IsDeleted => "IsDeleted",
		       Id => "Id",
		       CreateDate => "CreateDate",
		       UpdateDate => "UpdateDate",
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public int GetPropertyCode(string propertyName)
		{
		    return propertyName switch
		    {
		        "Settings" => Settings,
		        "FirstName" => FirstName,
		        "LastName" => LastName,
		        "Email" => Email,
		        "PrimaryPhone" => PrimaryPhone,
		        "SecundaryPhone" => SecundaryPhone,
		        "Address" => Address,
		        "IsDeleted" => IsDeleted,
		        "Id" => Id,
		        "CreateDate" => CreateDate,
		        "UpdateDate" => UpdateDate,
		
		        _ => -1,
		    };
		}
		
		public Type GetPropertyType(int propertyCode)
		{
		    return propertyCode switch
		    {
		        Settings => typeof(Dictionary<string,string>),
		        FirstName => typeof(string),
		        LastName => typeof(string),
		        Email => typeof(string),
		        PrimaryPhone => typeof(string),
		        SecundaryPhone => typeof(string),
		        Address => typeof(AddressDto),
		        IsDeleted => typeof(bool),
		        Id => typeof(int),
		        CreateDate => typeof(DateTime?),
		        UpdateDate => typeof(DateTime?),
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		       
		public object GetValue(object target, int propertyCode)
		{
		    UserDto obj = (UserDto)target;
		    return propertyCode switch
		    {
		        Settings => obj.Settings,
		        FirstName => obj.FirstName,
		        LastName => obj.LastName,
		        Email => obj.Email,
		        PrimaryPhone => obj.PrimaryPhone,
		        SecundaryPhone => obj.SecundaryPhone,
		        Address => obj.Address,
		        IsDeleted => obj.IsDeleted,
		        Id => obj.Id,
		        CreateDate => obj.CreateDate,
		        UpdateDate => obj.UpdateDate,
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public void SetValue(object target, int propertyCode, object value)
		{
		    UserDto obj = (UserDto)target;
		    switch (propertyCode)
		    {
		        case Settings:  obj.Settings = (Dictionary<string,string>)value;break;
		        case FirstName:  obj.FirstName = (string)value;break;
		        case LastName:  obj.LastName = (string)value;break;
		        case Email:  obj.Email = (string)value;break;
		        case PrimaryPhone:  obj.PrimaryPhone = (string)value;break;
		        case SecundaryPhone:  obj.SecundaryPhone = (string)value;break;
		        case Address:  obj.Address = (AddressDto)value;break;
		        case IsDeleted:  obj.IsDeleted = (bool)value;break;
		        case Id:  obj.Id = (int)value;break;
		        case CreateDate:  obj.CreateDate = (DateTime?)value;break;
		        case UpdateDate:  obj.UpdateDate = (DateTime?)value;break;
		
		        default: throw new InvalidOperationException("property code not supported");
		    }
		}
	
	}

}
