using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly DapperContext _dapperContext;

        public SliderService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            string query = "select * from TblSlider";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultSliderDto>(query);
            return values.ToList();
        }
    }
}
