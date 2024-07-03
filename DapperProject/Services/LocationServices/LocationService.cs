
using Dapper;
using DapperProject.Context;
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
    }
}
