using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.KaggleDatasetDtos;

namespace DapperProject.Services.KaggleDatasetService
{
    public class DataSetService : IDataSetService
    {
        private readonly DapperContext _dapperContext;

        public DataSetService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> GellDataCountAsync()
        {
            string query = "select count(*) from TblDataSet";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<ResultDataDto>> GetAllDataAsync()
        {
            string query = "select * from TblDataSet";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDataDto>(query);
            return values.ToList();

        }

        public async Task<decimal> GetAllDataAvgPriceAsync()
        {
            string query = "select avg(price) from TblDataSet";
            var connection = _dapperContext.CreateConnection();
            decimal value = await connection.QueryFirstOrDefaultAsync<decimal>(query);
            return value;
        }

        public async Task<int> GettAllAvgBedAsync()
        {
            string query = "select avg(bed) from TblDataSet";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<int> GettAllCityCountAsync()
        {
            string query = "select Count(distinct city) from TblDataSet";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    }
}
