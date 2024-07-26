using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
	public interface ILocationService
	{
		Task<int> GetAllLocationCountAsync();
		Task<List<ResultLocationDto>> GetAllLocationsAsync();
        Task CreateLocationAsync(CreateLocationDto createLocationDto);
        Task DeleteLocationAsync(int id);
        Task UpdateLocationAsync(UpdateLocationDto updateLocationDto);
        Task<GetByIdLocationDto> GetLocationAsync(int id);
    }
}
