using Smsark.Models;

using AutoMapper;
namespace Smsark.Mapping
{
	public class MappingProfile : Profile
{
		public MappingProfile()
		{
			CreateMap<CustomerRegister, Customer>();
		
		}
	}
}
