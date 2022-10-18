using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{

	void CreatePlatform(Platform platform);

	bool SaveChanges();

	Platform GetPlatformById(int id);

	IEnumerable<Platform> GetPlatforms();

}
