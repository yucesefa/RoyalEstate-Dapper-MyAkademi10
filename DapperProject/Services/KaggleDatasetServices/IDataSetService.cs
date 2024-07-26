using DapperProject.Dtos.KaggleDatasetDtos;

namespace DapperProject.Services.KaggleDatasetService
{
    public interface IDataSetService
    {
        Task<List<ResultDataDto>> GetAllDataAsync();
        Task<int> GellDataCountAsync();
        Task<int> GettAllCityCountAsync();
        Task<int> GettAllAvgBedAsync();
        Task<decimal> GetAllDataAvgPriceAsync();
    }
}
