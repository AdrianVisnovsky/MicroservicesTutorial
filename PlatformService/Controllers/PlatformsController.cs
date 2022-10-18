using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PlatformsController : ControllerBase
{

	private readonly IPlatformRepo _platformRepo;

	private readonly IMapper _mapper;

	public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
	{

		_platformRepo = platformRepo;
		_mapper = mapper;

	}

	[HttpGet]
	public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
	{

		IEnumerable<Platform> allPlatforms = _platformRepo.GetPlatforms();

		return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(allPlatforms));

	}

	[HttpGet("{id}", Name = "GetPlatform")]
	public ActionResult<PlatformReadDto> GetPlatform(int id)
	{

		Platform platform = _platformRepo.GetPlatformById(id);

		if (platform is null)
			return NotFound();

		return Ok(_mapper.Map<PlatformReadDto>(platform));
	}

	[HttpPost]
	public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto inputPlatform)
	{

		Platform platform = _mapper.Map<Platform>(inputPlatform);
		_platformRepo.CreatePlatform(platform);
		_platformRepo.SaveChanges();

		PlatformReadDto outputPlatform = _mapper.Map<PlatformReadDto>(platform);

		return CreatedAtRoute(nameof(GetPlatform), new {Id = outputPlatform.Id}, outputPlatform);
	}

}
