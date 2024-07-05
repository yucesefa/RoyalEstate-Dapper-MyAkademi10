using DapperProject.Dtos.AdvertDtos;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.AdvertServices
{
    public interface IAdvertService
    {
        Task<List<Last6AdvertDto>> GetLast6AdvertAsync();
        Task<List<Last4AdvertDto>> GetLast4AdvertAsync();
        Task<List<Last2AdvertDto>> GetLast2AdvertAsync();
        Task<int> GetAdvertCount();
        Task<float> GetMaxPrice();
        Task<float> GetMinPrice();
        Task<List<GetAdvertDetailCategoryCount>> GetAdvertDetailCategoryCountsAsync();
        Task<GetByIdAdvertDto> GetByIdAdvertAsync(int id);
        Task<List<ResultAdvertDto>> GetResultAdvertAsync();
        Task<List<ResultSliderDto>> GetResultSliderAdvertAsync();
        Task<List<GetListSearchAdvertDto>> GetListSearchAdvertAsync(string word,int location,float minPrice,float maxPrice,int category);
    }
}
