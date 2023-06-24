using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Product, ProductToReturnDto>()
			.ForMember(d => d.ProductCompany, o => o.MapFrom(s => s.ProductCompany.Name));
			CreateMap<ShiftTaskDto, ShiftTask>();
			CreateMap<TaskItemDto, TaskItem>();
		}
	}
}