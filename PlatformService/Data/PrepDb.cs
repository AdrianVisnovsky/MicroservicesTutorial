using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{

	public static void PrepPopulation(IApplicationBuilder application)
	{

		using var serviceScope = application.ApplicationServices.CreateScope();

		SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

	}

	private static void SeedData(AppDbContext dbContext)
	{

		if (dbContext.Platforms.Any())
			return;

		dbContext.Platforms.AddRange(
			new Platform() { Name=".NET", Publisher="Microsoft", Cost="Free"},
			new Platform() { Name="SQL Server", Publisher="Microsoft", Cost="Paid"},
			new Platform() { Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
		);

		dbContext.SaveChanges();

	}

}
