using System;
using Cybtans.Serialization;

namespace Service.Models
{
	public partial class UserFollowingsDto : IReflectorMetadataProvider
	{
		private static readonly UserFollowingsDtoAccesor __accesor = new UserFollowingsDtoAccesor();
		
		public int FollowerId {get; set;}
		
		public int FollowingId {get; set;}
		
		public UserDto Follower {get; set;}
		
		public UserDto Following {get; set;}
		
		public IReflectorMetadata GetAccesor()
		{
			return __accesor;
		}
	}
	
	
	public sealed class UserFollowingsDtoAccesor : IReflectorMetadata
	{
		public const int FollowerId = 1;
		public const int FollowingId = 2;
		public const int Follower = 3;
		public const int Following = 4;
		private readonly int[] _props = new []
		{
			FollowerId,FollowingId,Follower,Following
		};
		
		public int[] GetPropertyCodes() => _props;
		
		public string GetPropertyName(int propertyCode)
		{
		    return propertyCode switch
		    {
		       FollowerId => "FollowerId",
		       FollowingId => "FollowingId",
		       Follower => "Follower",
		       Following => "Following",
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public int GetPropertyCode(string propertyName)
		{
		    return propertyName switch
		    {
		        "FollowerId" => FollowerId,
		        "FollowingId" => FollowingId,
		        "Follower" => Follower,
		        "Following" => Following,
		
		        _ => -1,
		    };
		}
		
		public Type GetPropertyType(int propertyCode)
		{
		    return propertyCode switch
		    {
		        FollowerId => typeof(int),
		        FollowingId => typeof(int),
		        Follower => typeof(UserDto),
		        Following => typeof(UserDto),
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		       
		public object GetValue(object target, int propertyCode)
		{
		    UserFollowingsDto obj = (UserFollowingsDto)target;
		    return propertyCode switch
		    {
		        FollowerId => obj.FollowerId,
		        FollowingId => obj.FollowingId,
		        Follower => obj.Follower,
		        Following => obj.Following,
		
		        _ => throw new InvalidOperationException("property code not supported"),
		    };
		}
		
		public void SetValue(object target, int propertyCode, object value)
		{
		    UserFollowingsDto obj = (UserFollowingsDto)target;
		    switch (propertyCode)
		    {
		        case FollowerId:  obj.FollowerId = (int)value;break;
		        case FollowingId:  obj.FollowingId = (int)value;break;
		        case Follower:  obj.Follower = (UserDto)value;break;
		        case Following:  obj.Following = (UserDto)value;break;
		
		        default: throw new InvalidOperationException("property code not supported");
		    }
		}
	
	}

}
