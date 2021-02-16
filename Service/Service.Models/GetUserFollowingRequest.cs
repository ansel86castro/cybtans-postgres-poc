using System;
using Cybtans.Serialization;

namespace Service.Models
{
	public partial class GetUserFollowingRequest : IReflectorMetadataProvider
	{
		private static readonly GetUserFollowingRequestAccesor __accesor = new GetUserFollowingRequestAccesor();
		
		public int Id {get; set;}
		
		public string Filter {get; set;}
		
		public string Sort {get; set;}
		
		public int? Skip {get; set;}
		
		public int? Take {get; set;}
		
		public IReflectorMetadata GetAccesor()
		{
			return __accesor;
		}
	}
	
	
	public sealed class GetUserFollowingRequestAccesor : IReflectorMetadata
	{
		public const int Id = 1;
		public const int Filter = 2;
		public const int Sort = 3;
		public const int Skip = 4;
		public const int Take = 5;
		private readonly int[] _props = new []
		{
			Id,Filter,Sort,Skip,Take
		};
		
		public int[] GetPropertyCodes() => _props;
		
		public string GetPropertyName(int propertyCode)
		{
		    return propertyCode switch
		    {
		       Id => "Id",
		       Filter => "Filter",
		       Sort => "Sort",
		       Skip => "Skip",
		       Take => "Take",
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public int GetPropertyCode(string propertyName)
		{
		    return propertyName switch
		    {
		        "Id" => Id,
		        "Filter" => Filter,
		        "Sort" => Sort,
		        "Skip" => Skip,
		        "Take" => Take,
		
		        _ => -1,
		    };
		}
		
		public Type GetPropertyType(int propertyCode)
		{
		    return propertyCode switch
		    {
		        Id => typeof(int),
		        Filter => typeof(string),
		        Sort => typeof(string),
		        Skip => typeof(int?),
		        Take => typeof(int?),
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		       
		public object GetValue(object target, int propertyCode)
		{
		    GetUserFollowingRequest obj = (GetUserFollowingRequest)target;
		    return propertyCode switch
		    {
		        Id => obj.Id,
		        Filter => obj.Filter,
		        Sort => obj.Sort,
		        Skip => obj.Skip,
		        Take => obj.Take,
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public void SetValue(object target, int propertyCode, object value)
		{
		    GetUserFollowingRequest obj = (GetUserFollowingRequest)target;
		    switch (propertyCode)
		    {
		        case Id:  obj.Id = (int)value;break;
		        case Filter:  obj.Filter = (string)value;break;
		        case Sort:  obj.Sort = (string)value;break;
		        case Skip:  obj.Skip = (int?)value;break;
		        case Take:  obj.Take = (int?)value;break;
		
		        default: throw new InvalidOperationException("property code not supported");
		    }
		}
	
	}

}
