using PlatformService.Models;

namespace PlatformService.Data;

public sealed class PlatformRepo : IPlatformRepo
{

	#region private fields

	private readonly AppDbContext _dbContext;

	#endregion

	#region constructors

	public PlatformRepo(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	#endregion

	#region methods

	public void CreatePlatform(Platform platform)
	{
		ArgumentNullException.ThrowIfNull(platform);

		_dbContext.Platforms.Add(platform);
	}

	public Platform GetPlatformById(int id)
	{
		return _dbContext.Platforms.FirstOrDefault(p => p.Id == id);
	}

	public IEnumerable<Platform> GetPlatforms()
	{
		return _dbContext.Platforms.ToList();
	}

	public bool SaveChanges()
	{
		return _dbContext.SaveChanges() >= 0;
	}

	#endregion

}
