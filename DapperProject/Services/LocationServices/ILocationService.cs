using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
	public interface ILocationService
	{
		Task<int> GetAllLocationCountAsync();
		Task<List<ResultLocationDto>> GetAllLocationsAsync();
	}
}
