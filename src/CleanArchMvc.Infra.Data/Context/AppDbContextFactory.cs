using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CleanArchMvc.Infra.Data.Context;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext(string[] args)
	{
		var currentDirectory = Directory.GetCurrentDirectory();
		var currentDiParent = Directory.GetParent(currentDirectory);
		var appSettingDir = $@"{currentDiParent!.FullName}\CookBook.Api\";

		var configuration = new ConfigurationBuilder()
			.SetBasePath(appSettingDir)
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<AppDbContext>();
		var connectionString = configuration.GetConnectionString("Default");

		builder.UseSqlServer(connectionString);

		return new AppDbContext(builder.Options);
	}
}