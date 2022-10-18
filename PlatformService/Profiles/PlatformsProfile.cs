using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles;

public sealed class PlatformsProfile : Profile
{

	public PlatformsProfile()
	{

		CreateMap<Platform, PlatformReadDto>();
		CreateMap<PlatformCreateDto, Platform>();

	}

}
