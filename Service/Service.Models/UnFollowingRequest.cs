using System;
using Cybtans.Serialization;

namespace Service.Models
{
	public partial class UnFollowingRequest : IReflectorMetadataProvider
	{
		private static readonly UnFollowingRequestAccesor __accesor = new UnFollowingRequestAccesor();
		
		public int Id {get; set;}
		
		public int FollowingId {get; set;}
		
		public IReflectorMetadata GetAccesor()
		{
			return __accesor;
		}
	}
	
	
	public sealed class UnFollowingRequestAccesor : IReflectorMetadata
	{
		public const int Id = 1;
		public const int FollowingId = 2;
		private readonly int[] _props = new []
		{
			Id,FollowingId
		};
		
		public int[] GetPropertyCodes() => _props;
		
		public string GetPropertyName(int propertyCode)
		{
		    return propertyCode switch
		    {
		       Id => "Id",
		       FollowingId => "FollowingId",
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public int GetPropertyCode(string propertyName)
		{
		    return propertyName switch
		    {
		        "Id" => Id,
		        "FollowingId" => FollowingId,
		
		        _ => -1,
		    };
		}
		
		public Type GetPropertyType(int propertyCode)
		{
		    return propertyCode switch
		    {
		        Id => typeof(int),
		        FollowingId => typeof(int),
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		       
		public object GetValue(object target, int propertyCode)
		{
		    UnFollowingRequest obj = (UnFollowingRequest)target;
		    return propertyCode switch
		    {
		        Id => obj.Id,
		        FollowingId => obj.FollowingId,
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public void SetValue(object target, int propertyCode, object value)
		{
		    UnFollowingRequest obj = (UnFollowingRequest)target;
		    switch (propertyCode)
		    {
		        case Id:  obj.Id = (int)value;break;
		        case FollowingId:  obj.FollowingId = (int)value;break;
		
		        default: throw new InvalidOperationException("property code not supported");
		    }
		}
	
	}

}
