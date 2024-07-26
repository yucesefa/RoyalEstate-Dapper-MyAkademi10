
using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.LocationDtos;
using DapperProject.Dtos.LocationDtos;

namespace DapperProject.Services.LocationServices
{
	public class LocationService : ILocationService
	{
		private readonly DapperContext _context;

		public LocationService(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> GetAllLocationCountAsync()
		{
			string query = "select count(*) from TblLocation";
			var connection = _context.CreateConnection();
			int value = await connection.QueryFirstOrDefaultAsync<int>(query);
			return value;
		}

        public async Task<List<ResultLocationDto>> GetAllLocationsAsync()
        {
			string query = "select * from TblLocation";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultLocationDto>(query);
			return values.ToList();
        }

        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            string query = "insert into TblLocation (LocationName) values (@locationname)";
            var parameters = new DynamicParameters();
            parameters.Add("@locationname", createLocationDto.LocationName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "delete from TblLocation where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("@locationid", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task<GetByIdLocationDto> GetLocationAsync(int id)
        {
            string query = "select * from TblLocation Where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("locationid", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
            return values;
        }
        public async Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            string query = "update TblLocation Set LocationName=@locationname where LocationId=@locationid";
            var parameters = new DynamicParameters();
            parameters.Add("@locationname", updateLocationDto.LocationName);
            parameters.Add("@locationid", updateLocationDto.LocationId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
